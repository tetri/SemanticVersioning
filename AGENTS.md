# AI Agent Guide for SemanticVersioning

Welcome to the SemanticVersioning repository! This document contains essential information and guidelines to help AI agents (like you) work effectively within this codebase.

## Project Overview

This is a robust [Semantic Versioning 2.0.0](https://semver.org/) implementation for .NET with full support for parsing, comparison, and version operations.

- **Language:** C# 11.0
- **Framework:** .NET 9.0 / .NET 10.0
- **Testing Framework:** xUnit
- **Core Library Path:** `src/SemanticVersioning/`
- **Tests Path:** `tests/SemanticVersioning.Tests/`

## Environment Setup & Commands

- **Build:** `dotnet build`
- **Test:** `dotnet test`
- **Check outdated packages:** `dotnet list package --outdated`
- **Update package:** `dotnet add [Project.csproj] package [PackageName] -v [Version]`

## Coding Guidelines

1. **Immutability:** Core structs/classes like `SemanticVersion` should be immutable.
2. **Nullable Reference Types:** Nullable reference types (`<Nullable>enable</Nullable>`) are enabled. Pay close attention to `?` and handle nulls correctly.
3. **Thread Safety:** Ensure methods (especially static parsers and comparers) are thread-safe.
4. **Validation:** Perform strict validation according to SemVer 2.0.0 rules.
5. **Testing:** Practice TDD when applicable. Tests are located in `tests/SemanticVersioning.Tests/`. Use `xUnit` assertions.

## Best Practices for AI Agents

1. **Verify Your Work:** Always run tests (`dotnet test`) after any code modification.
2. **Review Diff Carefully:** When using search-and-replace, make sure the context lines exactly match the target file.
3. **Follow Pre-Commit Steps:** Ensure all verifications, tests, and standard reviews are requested before submitting changes.

<!-- trail:start -->
## Trail — repo context graph

This repo is indexed in `.trail/cache/`: small linked markdown nodes that explain each
system and carry exact file:line spans, kept in sync with the code through git.

For ANY task here — understanding how something works, finding where code lives,
or scoping a change — get context from the graph before grepping or opening
source files. Re-ask freely (it's cheap) and reuse literal identifiers you
already have (symbol, error string, file name) as the query. New to this repo?
Run `trail map` first — a token-budgeted orientation (dir clusters, hubs,
hotspots), no LLM, no key.

- Run `trail ask "<your question>" --source` → ranked nodes with the relevant
  code spans inlined (each hit's ≤8-line crux by default; `--full` for whole
  definitions when the crux isn't enough). Match the tool to the task shape:
  for understanding or editing, the top node IS the answer — cite its
  `covers:` file:line spans and edit straight from `--source`. For
  exhaustive tasks ("every occurrence / every caller of this pattern"), ranked
  results are top-N, not complete — run `trail grep "<literal>"` instead
  (exhaustive over indexed files, grouped by enclosing symbol), falling back
  to raw `grep -rn` only for unindexed files.
- `trail skeleton <file>` → every definition's signature + span, ~10× cheaper
  than reading the file; use it to skim an API surface.
- `trail callers <symbol>` gives precomputed, exact edges — who calls this.
  Add `--direction out` for what it calls, or `--depth N` to walk
  transitively for the full blast radius. For structural questions, skip
  ranking and use this directly.
- Or browse: `.trail/cache/INDEX.md` lists every node; follow the links.
- Monorepos and folders of multiple repos rank fairly across sub-projects —
  hits carry `[scope/]` labels naming which one they're from. Narrow with
  `trail ask "<task>" --in <scope>/` once you know where you're working.

If a returned span is truncated ("+N more lines"), open the file at that exact
range before finalizing. Only open source files when a node genuinely lacks a
needed detail, and then at the exact file:line the node points to — never
re-read whole files.

After big code changes, refresh the graph with `trail build` (deterministic,
no API key, $0).
<!-- trail:end -->
