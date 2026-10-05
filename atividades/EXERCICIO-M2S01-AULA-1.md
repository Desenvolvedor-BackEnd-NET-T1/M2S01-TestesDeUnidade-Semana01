# Exercício Guiado M2S01

Este guia tem como objetivo orientar a criação do primeiro exercício prático do módulo: replicar a estrutura e a lógica de testes unitários para a classe `Calculadora`.

## Atividade 1 — Criar e configurar o projeto de testes

Nesta atividade, você vai criar um projeto xUnit, adicioná-lo à solução, referenciar o projeto da calculadora, compilar e executar o teste simples criado pelo template.

### 1. Criar o projeto de testes xUnit

Se o projeto de testes ainda não existir, execute o comando abaixo na raiz do repositório:

```bash
dotnet new xunit --name CalculadoraConsole.Tests --output CalculadoraConsole.Tests --framework net10.0
```

Esse comando cria uma estrutura inicial de testes com o framework xUnit.

### 2. Adicionar o projeto de testes à solução

Inclua o projeto de testes na solução da calculadora:

```bash
dotnet sln Calculadora.sln add CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

### 3. Adicionar referência ao projeto da calculadora

Agora, conecte o projeto de teste ao projeto principal da aplicação para que a classe `Calculadora` possa ser acessada pelos testes:

```bash
dotnet add CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj reference CalculadoraConsole/CalculadoraConsole.csproj
```

### 4. Verificar se a referência foi criada corretamente

Abra o arquivo `.csproj` do projeto de testes e confirme se existe uma referência ao projeto da calculadora.

### 5. Executar a build do projeto de testes

Compile o projeto de testes e a referência da calculadora:

```bash
dotnet build CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Se tudo estiver correto, a build deve terminar sem erros.

### 6. Executar o teste simples do template

Para rodar os testes criados, use:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

---

## Atividade 2 — Criar e executar o primeiro teste de soma

Nesta atividade, crie seu primeiro teste unitário: copie o trecho de código abaixo e cole no arquivo `CalculadoraConsole.Tests/UnitTest1.cs`, substituindo o conteúdo existente. Em seguida, salve o arquivo e execute o teste.

### Teste de soma

```csharp
using Xunit;

namespace CalculadoraConsole.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Soma_DeveSomarDoisValores()
        {
            decimal resultado = Calculadora.Soma(2m, 3m);

            Assert.Equal(5m, resultado);
        }
    }
}
```

### O que esse teste faz

- chama diretamente o método `Calculadora.Soma(2m, 3m)`
- compara o resultado obtido com o valor esperado
- usa `Assert.Equal` para confirmar que a operação está correta

### Executar o teste

Depois de salvar o arquivo, execute:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Se o teste estiver correto, a saída no terminal deve indicar sucesso.

---

## Atividade 3 — Expandir os testes das operações

Agora, amplie os testes da classe `Calculadora`. Crie três testes para cada operação — soma, subtração, multiplicação e divisão — totalizando 12 cenários. Use combinações diferentes de valores para cobrir resultados positivos, negativos e zero, conforme indicado abaixo.

Use os valores e resultados esperados abaixo:

| Operação | Cenário | Valores | Resultado esperado |
|---|---:|---|---|
| Soma | 1 | `2m` e `3m` | `5m` |
| Soma | 2 | `-4m` e `6m` | `2m` |
| Soma | 3 | `0m` e `7m` | `7m` |
| Subtração | 1 | `8m` e `3m` | `5m` |
| Subtração | 2 | `3m` e `8m` | `-5m` |
| Subtração | 3 | `5m` e `5m` | `0m` |
| Multiplicação | 1 | `4m` e `3m` | `12m` |
| Multiplicação | 2 | `-2m` e `3m` | `-6m` |
| Multiplicação | 3 | `5m` e `0m` | `0m` |
| Divisão | 1 | `12m` e `3m` | `4m` |
| Divisão | 2 | `-10m` e `2m` | `-5m` |
| Divisão | 3 | `5m` e `0m` | ??? |


---
