# SemanticVersioning

[![NuGet Version](https://img.shields.io/nuget/v/tetri.net.SemanticVersioning.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/tetri.net.SemanticVersioning/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/tetri.net.SemanticVersioning.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/tetri.net.SemanticVersioning/)
[![License](https://img.shields.io/github/license/tetri/SemanticVersioning.svg?style=flat-square&logo=github)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/tetri/SemanticVersioning/build-and-test.yml?style=flat-square&logo=github&label=build)](https://github.com/tetri/SemanticVersioning/actions/workflows/build-and-test.yml)
[![Publish](https://img.shields.io/github/actions/workflow/status/tetri/SemanticVersioning/publish.yml?style=flat-square&logo=nuget&label=publish)](https://github.com/tetri/SemanticVersioning/actions/workflows/publish.yml)
[![AppVeyor Build Status](https://img.shields.io/appveyor/build/tetri/semanticversioning?style=flat-square&logo=appveyor)](https://ci.appveyor.com/project/tetri/semanticversioning)
[![Conventional Commits](https://img.shields.io/badge/conventional%20commits-1.0.0-%23FE5196?style=flat-square&logo=git)](https://www.conventionalcommits.org)

A robust [Semantic Versioning 2.0.0](https://semver.org/) implementation for .NET with full support for parsing, comparison, and version operations.

## 📦 Installation

Install via NuGet Package Manager:

```bash
dotnet add package tetri.net.SemanticVersioning
```

Or add directly to your `.csproj`:

```xml
<PackageReference Include="tetri.net.SemanticVersioning" Version="0.2.2" />
```

## 🚀 Quick Start

### Creating versions
```csharp
// From string
var version = new SemanticVersion("1.2.3-alpha.1+20240301");

// Using constructor
var version = new SemanticVersion(major: 1, minor: 2, patch: 3, prerelease: "alpha.1", build: "20240301");
```

### Comparing versions
```csharp
var v1 = new SemanticVersion("1.2.3");
var v2 = new SemanticVersion("1.3.0");

if (v1 < v2) 
{
    Console.WriteLine($"{v1} is less than {v2}");
}
```

### Supported operations
```csharp
// Equality
bool equal = v1 == v2; 

// Comparison
bool greater = v1 > v2;

// Comparison methods
int result = v1.CompareTo(v2);
```

## ✨ Features

✅ Strict SemVer 2.0.0 string parsing  
✅ Full version comparison support  
✅ Pre-release support (alpha, beta, rc)  
✅ Build metadata support  
✅ Overloaded operators (==, !=, <, >, <=, >=)  
✅ Immutable and thread-safe  
✅ JSON/XML serialization ready  

## 📚 Advanced Examples

### Pre-releases
```csharp
var stable = new SemanticVersion("1.0.0");
var beta = new SemanticVersion("1.0.0-beta.2");

Console.WriteLine(stable > beta); // True - stable versions have precedence
```

### Build metadata
```csharp
var v1 = new SemanticVersion("1.0.0+build.1");
var v2 = new SemanticVersion("1.0.0+build.2");

Console.WriteLine(v1 == v2); // True - build metadata doesn't affect equality
```

## 🛠️ Development

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later
- Git

### Setup

```bash
git clone https://github.com/tetri/SemanticVersioning.git
cd SemanticVersioning

# Enable commit hooks
dotnet tool restore 2>$null
git config core.hooksPath .githooks

# Build and test
dotnet build
dotnet test
```

### Conventional commits

This project enforces [Conventional Commits](https://www.conventionalcommits.org/).

```
type(optional-scope): description

Valid types: feat, fix, docs, style, refactor, perf, test, build, ci, chore, revert
```

The `.githooks/commit-msg` hook validates every commit locally. Pull requests are also validated in CI.

## 🤝 Contributing

We welcome contributions! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for full guidelines.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

Crafted with 🧠 by [Tetri Mesquita](https://tetri.net)