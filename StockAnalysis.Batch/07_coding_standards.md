# Coding Standards

> **APPROVED AND RELEASED.** This Standard is effective for its stated scope.

## 1. Purpose and scope

This Standard defines reusable implementation-quality controls for governed application, batch, API, automation, infrastructure, and database-integration work. It does not define language syntax, formatter settings, framework configuration, or build commands.

## 2. Principles

Implementation must be maintainable, readable, modular, testable, observable at an appropriate level, reproducible where applicable, and traceable to governed upstream authority. Development implements governed knowledge and architecture; it does not silently redefine them.

## 3. Structure and dependency

Code and configuration must keep responsibilities, boundaries, and dependencies explicit. Interfaces and configuration boundaries must be understandable. Dependencies must not silently invert established architecture or create hidden ownership of Knowledge Base, data, model, decision-engine, or Advisor rules.

## 4. Operational behavior

Failure behavior, recoverability expectations, and diagnostic context must be explicit at the level required by applicable controls. Implementations must not conceal material failure or uncertainty through unsupported defaults.

## 5. Traceability and review

Material implementation work must preserve relevant links to upstream authority, architecture direction, validation context, and resulting work product. Review and validation use Development Workflow, applicable testing controls, and Review Checklists.

## 6. Delegations

C#, .NET, EF Core, SQL, Azure, formatter, linter, naming syntax, patterns, commands, test frameworks, coverage thresholds, API contracts, schema rules, and deployment methods remain delegated to supplemental Standards, Procedures, or Guides.
