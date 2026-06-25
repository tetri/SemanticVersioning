# Contributing to SemanticVersioning

Thank you for your interest in contributing! This guide explains the contribution workflow, code standards, and commit conventions used in this project.

## Table of Contents

- [Getting Started](#getting-started)
- [Conventional Commits](#conventional-commits)
- [Workflow](#workflow)
- [Pull Request Checklist](#pull-request-checklist)
- [Code Style](#code-style)
- [Reporting Issues](#reporting-issues)

## Getting Started

1. Fork the repository.
2. Clone your fork:
   ```bash
   git clone https://github.com/YOUR-USERNAME/SemanticVersioning.git
   cd SemanticVersioning
   ```
3. Enable the commit hooks:
   ```bash
   git config core.hooksPath .githooks
   ```
   The hook validates that every commit follows the conventional commit format.
4. Create a branch:
   ```bash
   git checkout -b feat/my-feature
   ```
5. Build and test:
   ```bash
   dotnet build
   dotnet test
   ```

## Conventional Commits

This project enforces [Conventional Commits](https://www.conventionalcommits.org/) for all commits, including the `main` branch and pull requests.

### Format

```
type(optional-scope): description

[optional body]

[optional footer(s)]
```

### Allowed Types

| Type     | Usage                                    |
| -------- | ---------------------------------------- |
| `feat`   | A new feature                            |
| `fix`    | A bug fix                                |
| `docs`   | Documentation changes                     |
| `style`  | Formatting, missing semicolons, etc.      |
| `refactor` | Code refactoring without feature/bug change |
| `perf`   | Performance improvements                 |
| `test`   | Adding or fixing tests                   |
| `build`  | Build system or external dependency changes |
| `ci`     | CI configuration changes                 |
| `chore`  | Maintenance tasks, dependency bumps, etc. |
| `revert` | Reverts a previous commit                |

### Examples

```
feat: add prerelease comparison support
fix(parser): handle leading zeros in numeric identifiers
docs: update README with new API examples
test: add edge case tests for build metadata
chore(deps): bump xunit from 2.9.3 to 3.1.0
ci: add conventional commit validation step
refactor: extract version comparison logic
```

For breaking changes, add a `!` after the type/scope:

```
feat!: change CompareTo return semantics
feat(api)!: remove deprecated Parse method
```

## Workflow

1. **Create a branch** from `main` with a descriptive name:
   - `feat/description` — new features
   - `fix/description` — bug fixes
   - `docs/description` — documentation
   - `refactor/description` — refactoring

2. **Make your changes** following the [code style](#code-style).

3. **Commit** using conventional commit messages:
   ```bash
   git commit -m "feat: add support for version ranges"
   ```

4. **Keep your branch updated**:
   ```bash
   git fetch origin
   git rebase origin/main
   ```

5. **Push and open a pull request** against `main`.

## Pull Request Checklist

Before submitting your PR, ensure:

- [ ] All existing tests pass (`dotnet test`)
- [ ] New code includes tests where applicable
- [ ] Commits follow the conventional commit format
- [ ] Branch is rebased on the latest `main`
- [ ] No new warnings are introduced
- [ ] XML documentation comments are added for new public APIs

## Code Style

- **Language**: C# with nullable reference types enabled
- **Target framework**: `net9.0`
- **Indentation**: tabs
- **Naming**: PascalCase for public members, camelCase for parameters and private fields
- **Immutability**: `SemanticVersion` is a readonly struct — preserve this design
- **XML docs**: Add `///` comments to all public types, methods, and properties

## Reporting Issues

- **Bugs**: Open an issue with a minimal reproduction and the version you are using.
- **Feature requests**: Open an issue describing the use case and expected behavior.
- **Security vulnerabilities**: Do not open an issue — email `security@tetri.net` instead.
