using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace StockAnalysis.Batch.Services;

/// <summary>
/// ROHMの棚卸資産取得可能性を検証するための
/// EDINET限定Prototype Service。
///
/// Production Serviceではない。
/// DB保存、全企業取得、履歴Backfillは行わない。
/// </summary>
public class EdinetInventoryPrototypeService
{
    private const string EdinetDocumentListUrl =
        "https://api.edinet-fsa.go.jp/api/v2/documents.json";

    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// EDINET Prototype Serviceを初期化する。
    /// </summary>
    /// <param name="httpClient">
    /// EDINET API通信に使用するHttpClient。
    /// </param>
    /// <param name="configuration">
    /// EDINET API Key取得に使用するConfiguration。
    /// </param>
    public EdinetInventoryPrototypeService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    /// <summary>
    /// 指定日のEDINET書類一覧を取得し、
    /// 指定された証券コードに一致する提出書類のみを抽出する。
    ///
    /// Cross-company Validation Research専用のPrototype処理であり、
    /// Production用EDINET Document Discovery Serviceではない。
    /// </summary>
    /// <param name="filingDate">
    /// EDINET書類一覧を取得する提出日。
    /// </param>
    /// <param name="securityCode">
    /// EDINET Response上の証券コード。
    /// J-Quants等で使用する4桁コードではなく、
    /// EDINETで返却される5桁形式を指定する。
    /// </param>
    /// <returns>
    /// 指定日に対象証券コードの企業が提出した書類一覧。
    /// </returns>
    public async Task<List<EdinetDocumentDto>> GetDocumentsBySecurityCodeAsync(
        DateTime filingDate,
        string securityCode)
    {
        if (string.IsNullOrWhiteSpace(securityCode))
        {
            throw new ArgumentException(
                "証券コードが指定されていません。",
                nameof(securityCode));
        }

        // ConfigurationからAPI Keyを取得する。
        // API KeyはSource CodeへHardcodeしない。
        var apiKey = _configuration["Edinet:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "Edinet:ApiKey が設定されていません。");
        }

        // EDINET書類一覧APIは日付単位で取得する。
        // type=2を指定し、提出書類一覧とメタデータを取得する。
        //
        // EDINET API Version 2公式仕様に従い、
        // Subscription-KeyはRequest Parameterとして指定する。
        var requestUrl =
            $"{EdinetDocumentListUrl}" +
            $"?date={filingDate:yyyy-MM-dd}" +
            "&type=2" +
            $"&Subscription-Key={Uri.EscapeDataString(apiKey)}";

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            requestUrl);

        Console.WriteLine();
        Console.WriteLine(
            "EDINET Document List API 呼び出し中...");

        Console.WriteLine(
            $"Target Date  : {filingDate:yyyy-MM-dd}");

        Console.WriteLine(
            $"Security Code: {securityCode}");

        // EDINET APIへRequestを送信する。
        using var response =
            await _httpClient.SendAsync(request);

        var json =
            await response.Content.ReadAsStringAsync();

        // HTTP StatusだけではなくContent-Typeも確認する。
        // API Error Responseの識別に使用する。
        var contentType =
            response.Content.Headers.ContentType?.MediaType;

        Console.WriteLine(
            $"HTTP Status : {(int)response.StatusCode}");

        Console.WriteLine(
            $"Content-Type: {contentType ?? "(null)"}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"EDINET書類一覧取得失敗: " +
                $"{(int)response.StatusCode} {json}");
        }

        // JSON ResponseをEDINET DTOへ変換する。
        var result =
            JsonSerializer.Deserialize<EdinetDocumentListResponse>(
                json);

        if (result == null)
        {
            throw new InvalidOperationException(
                "EDINET書類一覧ResponseをDeserializeできませんでした。");
        }

        Console.WriteLine(
            $"EDINET Status : {result.Metadata?.Status ?? "(null)"}");

        Console.WriteLine(
            $"EDINET Message: {result.Metadata?.Message ?? "(null)"}");

        Console.WriteLine(
            $"Recognized Date: " +
            $"{result.Metadata?.Parameter?.Date ?? "(null)"}");

        Console.WriteLine(
            $"Recognized Type: " +
            $"{result.Metadata?.Parameter?.Type ?? "(null)"}");

        Console.WriteLine(
            $"ResultSet Count: " +
            $"{result.Metadata?.ResultSet?.Count.ToString() ?? "(null)"}");

        Console.WriteLine(
            $"DTO Result Count: {result.Results.Count}");

        // EDINET Response上の証券コードで対象企業を抽出する。
        //
        // Company Name文字列による部分一致は使用しない。
        // EDINET CodeはDocument List ResultからEvidenceとして確認する。
        var targetDocuments = result.Results
            .Where(x =>
                string.Equals(
                    x.SecurityCode,
                    securityCode,
                    StringComparison.Ordinal))
            .ToList();

        return targetDocuments;
    }

    /// <summary>
    /// EDINET書類取得APIからXBRL変換CSV ZIPを取得する。
    ///
    /// PrototypeではROHM第68期有価証券報告書
    /// S100YF41のみを対象とする。
    /// </summary>
    /// <param name="documentId">
    /// EDINET書類管理番号。
    /// </param>
    /// <returns>
    /// EDINETから取得したCSV ZIPのバイト配列。
    /// </returns>
    public async Task<byte[]> DownloadCsvZipAsync(
        string documentId)
    {
        if (string.IsNullOrWhiteSpace(documentId))
        {
            throw new ArgumentException(
                "EDINET書類管理番号が指定されていません。",
                nameof(documentId));
        }

        // ConfigurationからEDINET API Keyを取得する。
        // API KeyはSource CodeへHardcodeしない。
        var apiKey = _configuration["Edinet:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "Edinet:ApiKey が設定されていません。");
        }

        // EDINET書類取得APIでは、
        // URLへ書類管理番号を指定する。
        //
        // type=5はXBRL変換CSV ZIPの取得を表す。
        var requestUrl =
            $"https://api.edinet-fsa.go.jp/api/v2/documents/" +
            $"{Uri.EscapeDataString(documentId)}" +
            "?type=5" +
            $"&Subscription-Key={Uri.EscapeDataString(apiKey)}";

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            requestUrl);

        Console.WriteLine();
        Console.WriteLine(
            "EDINET CSV ZIP取得中...");

        Console.WriteLine(
            $"Document ID : {documentId}");

        // EDINET書類取得APIへRequestを送信する。
        using var response =
            await _httpClient.SendAsync(request);

        var contentType =
            response.Content.Headers.ContentType?.MediaType;

        Console.WriteLine(
            $"HTTP Status : {(int)response.StatusCode}");

        Console.WriteLine(
            $"Content-Type: {contentType ?? "(null)"}");

        // 書類取得APIではHTTP 200でも、
        // JSON形式のError Responseが返る可能性がある。
        //
        // そのためHTTP Statusだけで成功判定しない。
        if (!string.Equals(
                contentType,
                "application/octet-stream",
                StringComparison.OrdinalIgnoreCase))
        {
            var errorBody =
                await response.Content.ReadAsStringAsync();

            throw new HttpRequestException(
                "EDINET CSV ZIP取得失敗。" +
                Environment.NewLine +
                $"HTTP Status : {(int)response.StatusCode}" +
                Environment.NewLine +
                $"Content-Type: {contentType ?? "(null)"}" +
                Environment.NewLine +
                $"Response    : {errorBody}");
        }

        // ZIP BinaryをMemory上へ読み込む。
        // PrototypeではDBやFile Systemへ永続保存しない。
        var zipBytes =
            await response.Content.ReadAsByteArrayAsync();

        Console.WriteLine(
            $"ZIP Size     : {zipBytes.Length:N0} bytes");

        if (zipBytes.Length == 0)
        {
            throw new InvalidOperationException(
                "EDINET CSV ZIPが0 byteでした。");
        }

        return zipBytes;
    }

    /// <summary>
    /// EDINET書類取得APIから提出本文書等の
    /// XBRL関連ファイルZIPを取得する。
    ///
    /// PrototypeではROHM第68期有価証券報告書の
    /// Raw XBRL Fact存在確認に使用する。
    /// </summary>
    /// <param name="documentId">
    /// EDINET書類管理番号。
    /// </param>
    /// <returns>
    /// EDINETから取得したXBRL ZIPのバイト配列。
    /// </returns>
    public async Task<byte[]> DownloadXbrlZipAsync(
        string documentId)
    {
        if (string.IsNullOrWhiteSpace(documentId))
        {
            throw new ArgumentException(
                "EDINET書類管理番号が指定されていません。",
                nameof(documentId));
        }

        // ConfigurationからEDINET API Keyを取得する。
        // API KeyはSource CodeへHardcodeしない。
        var apiKey = _configuration["Edinet:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "Edinet:ApiKey が設定されていません。");
        }

        // EDINET書類取得APIでは、
        // type=1を指定して提出本文書及び監査報告書の
        // XBRL関連ファイルを取得する。
        var requestUrl =
            $"https://api.edinet-fsa.go.jp/api/v2/documents/" +
            $"{Uri.EscapeDataString(documentId)}" +
            "?type=1" +
            $"&Subscription-Key={Uri.EscapeDataString(apiKey)}";

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            requestUrl);

        Console.WriteLine();
        Console.WriteLine(
            "EDINET XBRL ZIP取得中...");

        Console.WriteLine(
            $"Document ID : {documentId}");

        // EDINET書類取得APIへRequestを送信する。
        using var response =
            await _httpClient.SendAsync(request);

        var contentType =
            response.Content.Headers.ContentType?.MediaType;

        Console.WriteLine(
            $"HTTP Status : {(int)response.StatusCode}");

        Console.WriteLine(
            $"Content-Type: {contentType ?? "(null)"}");

        // 書類取得APIではHTTP 200でも
        // JSON形式のError Responseとなる可能性がある。
        //
        // そのためHTTP Statusのみでは成功判定しない。
        if (!string.Equals(
                contentType,
                "application/octet-stream",
                StringComparison.OrdinalIgnoreCase))
        {
            var errorBody =
                await response.Content.ReadAsStringAsync();

            throw new HttpRequestException(
                "EDINET XBRL ZIP取得失敗。" +
                Environment.NewLine +
                $"HTTP Status : {(int)response.StatusCode}" +
                Environment.NewLine +
                $"Content-Type: {contentType ?? "(null)"}" +
                Environment.NewLine +
                $"Response    : {errorBody}");
        }

        // XBRL ZIP BinaryをMemory上へ読み込む。
        // PrototypeではFile Systemへ永続保存しない。
        var zipBytes =
            await response.Content.ReadAsByteArrayAsync();

        Console.WriteLine(
            $"ZIP Size     : {zipBytes.Length:N0} bytes");

        if (zipBytes.Length == 0)
        {
            throw new InvalidOperationException(
                "EDINET XBRL ZIPが0 byteでした。");
        }

        return zipBytes;
    }

    /// <summary>
    /// EDINET CSV ZIPに含まれるEntry一覧をConsoleへ表示する。
    ///
    /// Prototypeでは実際のZIP構造とCSVファイル名を
    /// Evidenceとして確認するために使用する。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したZIP Binary。
    /// </param>
    public void PrintCsvZipEntries(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "CSV ZIPデータが空です。",
                nameof(zipBytes));
        }

        // EDINETから取得したZIPをMemory上で開く。
        // PrototypeではFile Systemへ展開しない。
        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        Console.WriteLine();
        Console.WriteLine(
            "=== EDINET CSV ZIP ENTRIES ===");

        Console.WriteLine(
            $"Entry Count: {archive.Entries.Count}");

        foreach (var entry in archive.Entries)
        {
            Console.WriteLine(
                $"{entry.FullName} " +
                $"({entry.Length:N0} bytes)");
        }

        Console.WriteLine(
            "=== EDINET CSV ZIP ENTRIES END ===");
    }

    /// <summary>
    /// EDINET XBRL ZIPに含まれるEntry一覧をConsoleへ表示する。
    ///
    /// PrototypeではInstance Document及びTaxonomy関連Fileの
    /// 実際のDirectory構造とFile NameをEvidenceとして確認する。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したXBRL ZIP Binary。
    /// </param>
    public void PrintXbrlZipEntries(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "XBRL ZIPデータが空です。",
                nameof(zipBytes));
        }

        // EDINETから取得したXBRL ZIPをMemory上で開く。
        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        Console.WriteLine();
        Console.WriteLine(
            "=== EDINET XBRL ZIP ENTRIES ===");

        Console.WriteLine(
            $"Entry Count: {archive.Entries.Count}");

        foreach (var entry in archive.Entries)
        {
            Console.WriteLine(
                $"{entry.FullName} " +
                $"({entry.Length:N0} bytes)");
        }

        Console.WriteLine(
            "=== EDINET XBRL ZIP ENTRIES END ===");
    }

    /// <summary>
    /// EDINET XBRL変換CSV全体から、
    /// 棚卸資産及び棚卸資産構成項目に関連する
    /// Candidate行を検索してConsoleへ表示する。
    ///
    /// Prototype段階ではTotal Inventories単一Conceptの存在を仮定しない。
    /// 商品、製品、仕掛品、原材料、貯蔵品等の
    /// Component ConceptもRaw Evidenceとして確認する。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したCSV ZIP Binary。
    /// </param>
    public void PrintInventoryCandidateLines(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "CSV ZIPデータが空です。",
                nameof(zipBytes));
        }

        // Total Inventory及びInventory Component候補を検索する。
        //
        // Concept QNameと日本語Labelの双方に対して
        // Keyword Searchを行う。
        //
        // この段階ではConcept Mappingや合算処理を行わない。
        var searchKeywords = new[]
        {
            "棚卸資産",
            "Inventories",
            "Inventory",

            "商品",
            "製品",
            "仕掛品",
            "原材料",
            "貯蔵品",

            "Merchandise",
            "FinishedGoods",
            "Finished Goods",
            "WorkInProcess",
            "Work In Process",
            "RawMaterials",
            "Raw Materials",
            "Supplies"
        };

        // EDINET CSV ZIPをMemory上で開く。
        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        Console.WriteLine();
        Console.WriteLine(
            "=== EDINET INVENTORY COMPONENT CANDIDATE SEARCH ===");

        var totalMatchCount = 0;

        // ZIP内の全CSVを対象にする。
        //
        // 現時点では本文CSVのFile Nameを
        // Extraction RuleとしてHardcodeしない。
        foreach (var entry in archive.Entries
                     .Where(x =>
                         x.FullName.EndsWith(
                             ".csv",
                             StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine();
            Console.WriteLine(
                $"--- FILE: {entry.FullName} ---");

            var fileMatchCount = 0;

            using var entryStream =
                entry.Open();

            using var reader =
                new StreamReader(
                    entryStream,
                    Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: true);

            var lineNumber = 0;

            while (!reader.EndOfStream)
            {
                var line =
                    reader.ReadLine();

                lineNumber++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Inventory関連Keywordのいずれかを含む
                // Raw CSV行をCandidateとして抽出する。
                var matchedKeyword =
                    searchKeywords.FirstOrDefault(keyword =>
                        line.Contains(
                            keyword,
                            StringComparison.OrdinalIgnoreCase));

                if (matchedKeyword == null)
                {
                    continue;
                }

                fileMatchCount++;
                totalMatchCount++;

                Console.WriteLine();
                Console.WriteLine(
                    $"Line    : {lineNumber}");

                Console.WriteLine(
                    $"Keyword : {matchedKeyword}");

                Console.WriteLine(
                    $"Raw     : {line}");
            }

            Console.WriteLine();
            Console.WriteLine(
                $"File Match Count: {fileMatchCount}");
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Total Match Count: {totalMatchCount}");

        Console.WriteLine(
            "=== EDINET INVENTORY COMPONENT CANDIDATE SEARCH END ===");
    }

    /// <summary>
    /// EDINET XBRL変換CSVから、Inventory関連Keywordに一致した行について、
    /// Concept QName Candidateのみを重複除去して表示する。
    ///
    /// IFRS ValidationではJapanese GAAPのjppfs_cor Conceptを前提にせず、
    /// 実CSVに存在するNamespace Prefix及びConcept Local Nameを
    /// Discovery Evidenceとして確認するために使用する。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したCSV ZIP Binary。
    /// </param>
    public void PrintInventoryCandidateConceptNames(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "CSV ZIPデータが空です。",
                nameof(zipBytes));
        }

        // IFRS及びJapanese GAAP双方のInventory表現候補を広めに検索する。
        //
        // このKeyword SetはDiscovery用であり、
        // Production Concept Mapping Ruleではない。
        var searchKeywords = new[]
        {
        "棚卸資産",
        "Inventories",
        "Inventory",
        "Merchandise",
        "FinishedGoods",
        "Finished Goods",
        "WorkInProcess",
        "Work In Process",
        "WorkInProgress",
        "Work In Progress",
        "RawMaterials",
        "Raw Materials",
        "Supplies"
    };

        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        var conceptNames =
            new HashSet<string>(
                StringComparer.Ordinal);

        // ZIP内の全CSVを対象にInventory関連Concept Candidateを収集する。
        foreach (var entry in archive.Entries
                     .Where(x =>
                         x.FullName.EndsWith(
                             ".csv",
                             StringComparison.OrdinalIgnoreCase)))
        {
            using var entryStream =
                entry.Open();

            using var reader =
                new StreamReader(
                    entryStream,
                    Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: true);

            while (!reader.EndOfStream)
            {
                var line =
                    reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var isInventoryCandidate =
                    searchKeywords.Any(keyword =>
                        line.Contains(
                            keyword,
                            StringComparison.OrdinalIgnoreCase));

                if (!isInventoryCandidate)
                {
                    continue;
                }

                // EDINET CSVの先頭ColumnはConcept QNameであることを、
                // 既存Prototype実データから確認済み。
                //
                // ここではGeneric CSV Parserを実装せず、
                // Discovery専用として先頭Quoted Valueだけを取得する。
                var firstQuoteStart =
                    line.IndexOf('"');

                if (firstQuoteStart < 0)
                {
                    continue;
                }

                var firstQuoteEnd =
                    line.IndexOf(
                        '"',
                        firstQuoteStart + 1);

                if (firstQuoteEnd <= firstQuoteStart)
                {
                    continue;
                }

                var conceptName =
                    line.Substring(
                        firstQuoteStart + 1,
                        firstQuoteEnd - firstQuoteStart - 1);

                if (!string.IsNullOrWhiteSpace(conceptName))
                {
                    conceptNames.Add(conceptName);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine(
            "=== EDINET INVENTORY CONCEPT NAME CANDIDATES ===");

        Console.WriteLine(
            $"Candidate Count: {conceptNames.Count}");

        foreach (var conceptName in conceptNames
                     .OrderBy(x => x))
        {
            Console.WriteLine(
                conceptName);
        }

        Console.WriteLine(
            "=== EDINET INVENTORY CONCEPT NAME CANDIDATES END ===");
    }

    /// <summary>
    /// EDINET Raw XBRL Instance Documentから、
    /// 棚卸資産関連のNumeric Fact Candidateを検索して表示する。
    ///
    /// CSV TextBlock内に存在した棚卸資産構成項目が、
    /// Raw XBRL上では独立したFact Elementとして存在するかを
    /// Cross-checkするために使用する。
    ///
    /// Prototype段階ではConcept Mapping、合算、DB保存を行わない。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したXBRL ZIP Binary。
    /// </param>
    public void PrintXbrlInventoryCandidateFacts(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "XBRL ZIPデータが空です。",
                nameof(zipBytes));
        }

        // Inventory及びInventory Componentに関連する
        // Concept Local Name候補。
        //
        // Raw XBRL Instanceでは日本語Labelではなく、
        // XML Element QNameを対象に検索する。
        var conceptKeywords = new[]
        {
        "Inventory",
        "Inventories",
        "Merchandise",
        "FinishedGoods",
        "FinishedGood",
        "WorkInProcess",
        "RawMaterials",
        "RawMaterial",
        "Supplies"
    };

        // EDINET XBRL ZIPをMemory上で開く。
        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        Console.WriteLine();
        Console.WriteLine(
            "=== EDINET XBRL INVENTORY FACT CANDIDATE SEARCH ===");

        var totalMatchCount = 0;

        // ZIP内のRaw XBRL Instance Candidateを走査する。
        //
        // Taxonomy SchemaやLinkbaseではなく、
        // 実Fact Valueを持つInstance Documentを確認するため、
        // .xbrl Fileのみを対象とする。
        foreach (var entry in archive.Entries
                     .Where(x =>
                         x.FullName.EndsWith(
                             ".xbrl",
                             StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine();
            Console.WriteLine(
                $"--- FILE: {entry.FullName} ---");

            var fileMatchCount = 0;

            using var entryStream =
                entry.Open();

            // XBRL InstanceをXMLとしてStreaming Parseする。
            //
            // Document全体をMemoryへ展開せず、
            // Prototypeでも巨大Fileに耐えやすい方式とする。
            var settings =
                new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Prohibit,
                    XmlResolver = null
                };

            using var reader =
                XmlReader.Create(
                    entryStream,
                    settings);

            while (reader.Read())
            {
                // XBRL Fact CandidateはXML Elementとして表現される。
                if (reader.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                var localName =
                    reader.LocalName;

                // Concept Local NameにInventory関連Keywordを含むか確認する。
                var matchedKeyword =
                    conceptKeywords.FirstOrDefault(keyword =>
                        localName.Contains(
                            keyword,
                            StringComparison.OrdinalIgnoreCase));

                if (matchedKeyword == null)
                {
                    continue;
                }

                // Context及びUnitを取得する。
                //
                // Numeric Fact Candidate判定に必要なLineage情報として
                // Raw Attributeを保持する。
                var contextRef =
                    reader.GetAttribute("contextRef");

                var unitRef =
                    reader.GetAttribute("unitRef");

                var decimals =
                    reader.GetAttribute("decimals");

                var namespaceUri =
                    reader.NamespaceURI;

                var prefix =
                    reader.Prefix;

                // Empty Elementの場合はValueを持たないため空文字とする。
                //
                // 通常のFact ElementではElement Contentを取得する。
                var value =
                    reader.IsEmptyElement
                        ? string.Empty
                        : reader.ReadElementContentAsString();

                fileMatchCount++;
                totalMatchCount++;

                Console.WriteLine();
                Console.WriteLine(
                    $"Keyword   : {matchedKeyword}");

                Console.WriteLine(
                    $"QName     : " +
                    $"{(string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix + ":")}" +
                    $"{localName}");

                Console.WriteLine(
                    $"Namespace : {namespaceUri}");

                Console.WriteLine(
                    $"ContextRef: {contextRef ?? "(null)"}");

                Console.WriteLine(
                    $"UnitRef   : {unitRef ?? "(null)"}");

                Console.WriteLine(
                    $"Decimals  : {decimals ?? "(null)"}");

                Console.WriteLine(
                    $"Value     : {value}");
            }

            Console.WriteLine();
            Console.WriteLine(
                $"File Match Count: {fileMatchCount}");
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Total Match Count: {totalMatchCount}");

        Console.WriteLine(
            "=== EDINET XBRL INVENTORY FACT CANDIDATE SEARCH END ===");
    }

    /// <summary>
    /// Raw XBRL Instanceから、Kioxia IFRS Inventory Validationで確認した
    /// Total Inventory及びInventory Component Value Candidateを検索する。
    ///
    /// IFRSのConcept Naming Variationを調査するResearch Helperであり、
    /// Production Extraction Ruleではない。
    /// </summary>
    /// <param name="zipBytes">
    /// EDINET書類取得APIから取得したXBRL ZIP Binary。
    /// </param>
    public void PrintKioxiaInventoryFactsByKnownValues(
        byte[] zipBytes)
    {
        if (zipBytes == null ||
            zipBytes.Length == 0)
        {
            throw new ArgumentException(
                "XBRL ZIPデータが空です。",
                nameof(zipBytes));
        }

        // CSV及びInventory Noteから確認済みのInventory Value。
        //
        // Concept QNameが現在のKeyword Searchで取得できなかった
        // Half-finished Goods / Work in Process Candidateを含め、
        // Raw XBRL上の実Element QNameをDiscoveryする。
        var targetValues = new HashSet<string>(
            StringComparer.Ordinal)
    {
        "352863000000",
        "412612000000",

        "50549000000",
        "53232000000",

        "283746000000",
        "280183000000",

        "18486000000",
        "79093000000",

        "82000000",
        "104000000"
    };

        using var zipStream =
            new MemoryStream(zipBytes);

        using var archive =
            new ZipArchive(
                zipStream,
                ZipArchiveMode.Read);

        Console.WriteLine();
        Console.WriteLine(
            "=== KIOXIA XBRL INVENTORY KNOWN VALUE DISCOVERY ===");

        var totalMatchCount = 0;

        foreach (var entry in archive.Entries
                     .Where(x =>
                         x.FullName.EndsWith(
                             ".xbrl",
                             StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine();
            Console.WriteLine(
                $"--- FILE: {entry.FullName} ---");

            var fileMatchCount = 0;

            using var entryStream =
                entry.Open();

            var settings =
                new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Prohibit,
                    XmlResolver = null
                };

            using var reader =
                XmlReader.Create(
                    entryStream,
                    settings);

            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                // Numeric Fact Candidateとして、
                // ContextRef及びUnitRefを持つElementのみ確認する。
                var contextRef =
                    reader.GetAttribute("contextRef");

                var unitRef =
                    reader.GetAttribute("unitRef");

                if (string.IsNullOrWhiteSpace(contextRef) ||
                    string.IsNullOrWhiteSpace(unitRef))
                {
                    continue;
                }

                var localName =
                    reader.LocalName;

                var namespaceUri =
                    reader.NamespaceURI;

                var prefix =
                    reader.Prefix;

                var decimals =
                    reader.GetAttribute("decimals");

                var value =
                    reader.IsEmptyElement
                        ? string.Empty
                        : reader.ReadElementContentAsString();

                if (!targetValues.Contains(value))
                {
                    continue;
                }

                fileMatchCount++;
                totalMatchCount++;

                Console.WriteLine();
                Console.WriteLine(
                    $"QName     : " +
                    $"{(string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix + ":")}" +
                    $"{localName}");

                Console.WriteLine(
                    $"Namespace : {namespaceUri}");

                Console.WriteLine(
                    $"ContextRef: {contextRef}");

                Console.WriteLine(
                    $"UnitRef   : {unitRef}");

                Console.WriteLine(
                    $"Decimals  : {decimals ?? "(null)"}");

                Console.WriteLine(
                    $"Value     : {value}");
            }

            Console.WriteLine();
            Console.WriteLine(
                $"File Match Count: {fileMatchCount}");
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Total Match Count: {totalMatchCount}");

        Console.WriteLine(
            "=== KIOXIA XBRL INVENTORY KNOWN VALUE DISCOVERY END ===");
    }
}