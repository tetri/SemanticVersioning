# SemanticVersioning

Implementação de versionamento semântico (SemVer 2.0.0) em C#.

## Instalação

```bash
dotnet add package SemanticVersioning
```

## Uso

```csharp
var version1 = new SemanticVersion("1.2.3-alpha.1");
var version2 = new SemanticVersion("1.2.3");

if (version1 < version2)
{
    Console.WriteLine("version1 é menor que version2");
}
```

## Recursos
- Parsing de strings SemVer
- Comparação completa entre versões
- Suporte a pré-release e build metadata
- Operadores de comparação (<, >, ==, etc.)
