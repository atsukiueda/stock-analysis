using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockAnalysis.Batch.Data;

public class StockAnalysisDbContextFactory
    : IDesignTimeDbContextFactory<StockAnalysisDbContext>
{
    public StockAnalysisDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<StockAnalysisDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=tcp:stockanalysis-sqlsvr.database.windows.net,1433;Initial Catalog=StockAnalysisDb;Persist Security Info=False;User ID=stockadmin;Password=893&Bihun4610!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            });

        return new StockAnalysisDbContext(optionsBuilder.Options);
    }
}