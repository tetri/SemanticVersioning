# SemanticVersioning

[![NuGet Version](https://img.shields.io/nuget/v/tetri.net.SemanticVersioning.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/tetri.net.SemanticVersioning/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/tetri.net.SemanticVersioning.svg?style=flat-square&logo=nuget)](https://www.nuget.org/packages/tetri.net.SemanticVersioning/)
[![License](https://img.shields.io/github/license/tetri/SemanticVersioning.svg?style=flat-square&logo=github)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/tetri/SemanticVersioning/build-and-test.yml?style=flat-square&logo=github&label=build)](https://github.com/tetri/SemanticVersioning/actions/workflows/build-and-test.yml)
[![Publish](https://img.shields.io/github/actions/workflow/status/tetri/SemanticVersioning/publish.yml?style=flat-square&logo=nuget&label=publish)](https://github.com/tetri/SemanticVersioning/actions/workflows/publish.yml)
[![AppVeyor Build Status](https://img.shields.io/appveyor/build/tetri/semanticversioning?style=flat-square&logo=appveyor)](https://ci.appveyor.com/project/tetri/semanticversioning)
[![Conventional Commits](https://img.shields.io/badge/conventional%20commits-1.0.0-%23FE5196?style=flat-square&logo=git)](https://www.conventionalcommits.org)

Uma implementação robusta de [Versionamento Semântico 2.0.0](https://semver.org/) para .NET com suporte completo a parsing, comparação e operações de versão.

## 📦 Instalação

Instale via NuGet Package Manager:

```bash
dotnet add package tetri.net.SemanticVersioning
```

Ou adicione diretamente ao seu `.csproj`:

```xml
<PackageReference Include="tetri.net.SemanticVersioning" Version="0.2.2" />
```

## 🚀 Guia Rápido

### Criando versões
```csharp
// A partir de string
var version = new SemanticVersion("1.2.3-alpha.1+20240301");

// Usando construtor
var version = new SemanticVersion(major: 1, minor: 2, patch: 3, prerelease: "alpha.1", build: "20240301");
```

### Comparando versões
```csharp
var v1 = new SemanticVersion("1.2.3");
var v2 = new SemanticVersion("1.3.0");

if (v1 < v2)
{
    Console.WriteLine($"{v1} é menor que {v2}");
}
```

### Operações suportadas
```csharp
// Igualdade
bool equal = v1 == v2;

// Comparação
bool greater = v1 > v2;

// Métodos de comparação
int result = v1.CompareTo(v2);
```

## ✨ Funcionalidades

✅ Parsing estrito de strings SemVer 2.0.0  
✅ Suporte completo a comparação de versões  
✅ Suporte a pré-lançamento (alpha, beta, rc)  
✅ Suporte a metadados de build  
✅ Operadores sobrecarregados (==, !=, <, >, <=, >=)  
✅ Imutável e thread-safe  
✅ Pronto para serialização JSON/XML  

## 📚 Exemplos Avançados

### Pré-lançamentos
```csharp
var stable = new SemanticVersion("1.0.0");
var beta = new SemanticVersion("1.0.0-beta.2");

Console.WriteLine(stable > beta); // True - versões estáveis têm precedência
```

### Metadados de build
```csharp
var v1 = new SemanticVersion("1.0.0+build.1");
var v2 = new SemanticVersion("1.0.0+build.2");

Console.WriteLine(v1 == v2); // True - metadados de build não afetam a igualdade
```

## 🛠️ Desenvolvimento

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) ou superior
- Git

### Configuração

```bash
git clone https://github.com/tetri/SemanticVersioning.git
cd SemanticVersioning

# Ativar hooks de commit
git config core.hooksPath .githooks

# Compilar e testar
dotnet build
dotnet test
```

### Commits convencionais

Este projeto utiliza [Conventional Commits](https://www.conventionalcommits.org/).

```
tipo(escopo-opcional): descrição

Tipos válidos: feat, fix, docs, style, refactor, perf, test, build, ci, chore, revert
```

O hook `.githooks/commit-msg` valida cada commit localmente. Pull requests também são validadas na CI.

## 🤝 Contribuição

Contribuições são bem-vindas! Leia [CONTRIBUTING.pt-BR.md](CONTRIBUTING.pt-BR.md) para as diretrizes completas.

## 📄 Licença

Este projeto está licenciado sob a Licença MIT — veja o arquivo [LICENSE](LICENSE) para detalhes.

---

Criado com 🧠 por [Tetri Mesquita](https://tetri.net)
