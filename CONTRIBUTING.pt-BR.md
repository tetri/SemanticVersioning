# Contribuindo com o SemanticVersioning

Obrigado pelo interesse em contribuir! Este guia explica o fluxo de contribuição, padrões de código e convenções de commit usadas neste projeto.

## Sumário

- [Primeiros Passos](#primeiros-passos)
- [Conventional Commits](#conventional-commits)
- [Fluxo de Trabalho](#fluxo-de-trabalho)
- [Checklist do Pull Request](#checklist-do-pull-request)
- [Estilo de Código](#estilo-de-código)
- [Reportando Problemas](#reportando-problemas)

## Primeiros Passos

1. Faça um fork do repositório.
2. Clone o seu fork:
   ```bash
   git clone https://github.com/SEU-USUARIO/SemanticVersioning.git
   cd SemanticVersioning
   ```
3. Ative os hooks de commit:
   ```bash
   git config core.hooksPath .githooks
   ```
   O hook valida que todo commit segue o formato conventional commit.
4. Crie um branch:
   ```bash
   git checkout -b feat/minha-feature
   ```
5. Compile e teste:
   ```bash
   dotnet build
   dotnet test
   ```

## Conventional Commits

Este projeto utiliza [Conventional Commits](https://www.conventionalcommits.org/) para todos os commits, incluindo o branch `main` e pull requests.

### Formato

```
tipo(escopo-opcional): descrição

[corpo opcional]

[rodapé(s) opcional(is)]
```

### Tipos Permitidos

| Tipo       | Uso                                           |
| ---------- | --------------------------------------------- |
| `feat`     | Uma nova funcionalidade                       |
| `fix`      | Uma correção de bug                           |
| `docs`     | Mudanças na documentação                      |
| `style`    | Formatação, ponto-e-vírgulas faltando, etc.    |
| `refactor` | Refatoração sem mudança de funcionalidade/bug |
| `perf`     | Melhorias de performance                      |
| `test`     | Adicionando ou corrigindo testes              |
| `build`    | Sistema de build ou mudanças em dependências  |
| `ci`       | Mudanças na configuração de CI                |
| `chore`    | Tarefas de manutenção, bumps de dependência   |
| `revert`   | Reverte um commit anterior                    |

### Exemplos

```
feat: adicionar suporte a comparação de pré-lançamento
fix(parser): tratar zeros à esquerda em identificadores numéricos
docs: atualizar README com novos exemplos de API
test: adicionar testes de borda para metadados de build
chore(deps): atualizar xunit de 2.9.3 para 3.1.0
ci: adicionar etapa de validação conventional commit
refactor: extrair lógica de comparação de versões
```

Para mudanças que quebram compatibilidade, adicione `!` após o tipo/escopo:

```
feat!: mudar semântica de retorno do CompareTo
feat(api)!: remover método Parse obsoleto
```

## Fluxo de Trabalho

1. **Crie um branch** a partir de `main` com um nome descritivo:
   - `feat/descricao` — novas funcionalidades
   - `fix/descricao` — correções de bug
   - `docs/descricao` — documentação
   - `refactor/descricao` — refatoração

2. **Faça suas alterações** seguindo o [estilo de código](#estilo-de-código).

3. **Commite** usando mensagens conventional commit:
   ```bash
   git commit -m "feat: adicionar suporte a ranges de versão"
   ```

4. **Mantenha seu branch atualizado**:
   ```bash
   git fetch origin
   git rebase origin/main
   ```

5. **Envie e abra um pull request** contra `main`.

## Checklist do Pull Request

Antes de enviar seu PR, verifique:

- [ ] Todos os testes existentes passam (`dotnet test`)
- [ ] Código novo inclui testes quando aplicável
- [ ] Commits seguem o formato conventional commit
- [ ] Branch está rebaseado no `main` mais recente
- [ ] Nenhum aviso novo é introduzido
- [ ] Comentários de documentação XML são adicionados para novas APIs públicas

## Estilo de Código

- **Linguagem**: C# com nullable reference types habilitado
- **Target framework**: `net9.0`
- **Indentação**: tabs
- **Nomenclatura**: PascalCase para membros públicos, camelCase para parâmetros e campos privados
- **Imutabilidade**: `SemanticVersion` é um readonly struct — preserve este design
- **Documentação XML**: Adicione comentários `///` a todos os tipos, métodos e propriedades públicas

## Reportando Problemas

- **Bugs**: Abra uma issue com uma reprodução mínima e a versão que você está usando.
- **Solicitações de funcionalidade**: Abra uma issue descrevendo o caso de uso e comportamento esperado.
- **Vulnerabilidades de segurança**: Não abra uma issue pública — envie um email para `security@tetri.net`.
