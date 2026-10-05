# Exercício Guiado M2S01 — Aula 2

## Objetivo

Na aula 1, você criou testes para as operações da classe `Calculadora`. Nesta atividade, pratique diferentes recursos do xUnit para organizar e reutilizar cenários de teste:

1. `[Theory]` com `[InlineData]`
2. `[MemberData]`
3. `[ClassData]`
4. `TheoryData`
5. Fixture

Crie um exemplo de cada recurso no projeto `CalculadoraConsole.Tests`. Os exemplos abaixo usam a classe `Calculadora` criada na aula anterior.

## Preparação

Confirme que o projeto de testes tem uma referência ao projeto `CalculadoraConsole` e que os testes existentes compilam:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Os exemplos podem ficar em arquivos de teste separados dentro do projeto. Inclua os `using` necessários em cada arquivo.

## 1. `[Theory]` com `[InlineData]`

Use `[Theory]` para executar o mesmo teste várias vezes com os argumentos informados em cada `[InlineData]`. Neste exemplo, teste a multiplicação com três pares de valores.

```csharp
using Xunit;

namespace CalculadoraConsole.Tests;

public class MultiplicacaoTests
{
    [Theory]
    [InlineData(4m, 3m, 12m)]
    [InlineData(-2m, 3m, -6m)]
    [InlineData(5m, 0m, 0m)]
    public void Multiplicacao_DeveRetornarResultadoEsperado(
        decimal valor1,
        decimal valor2,
        decimal esperado)
    {
        decimal resultado = Calculadora.Multiplicacao(valor1, valor2);

        Assert.Equal(esperado, resultado);
    }
}
```

## 2. `[MemberData]`

Use `[MemberData]` quando os dados do teste estiverem em um membro estático, como uma propriedade ou método. Neste exemplo, os cenários de subtração são fornecidos por uma propriedade que retorna `IEnumerable<object[]>`.

```csharp
using System.Collections.Generic;
using Xunit;

namespace CalculadoraConsole.Tests;

public class SubtracaoTests
{
    public static IEnumerable<object[]> CasosDeSubtracao =>
        new List<object[]>
        {
            new object[] { 8m, 3m, 5m },
            new object[] { 3m, 8m, -5m },
            new object[] { 5m, 5m, 0m }
        };

    [Theory]
    [MemberData(nameof(CasosDeSubtracao))]
    public void Subtracao_DeveRetornarResultadoEsperado(
        decimal valor1,
        decimal valor2,
        decimal esperado)
    {
        decimal resultado = Calculadora.Subtracao(valor1, valor2);

        Assert.Equal(esperado, resultado);
    }
}
```

## 3. `[ClassData]`

Use `[ClassData]` para manter os cenários em uma classe separada. A classe de dados implementa `IEnumerable<object[]>`. Neste exemplo, ela fornece os cenários de divisão.

```csharp
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CalculadoraConsole.Tests;

public class CasosDeDivisao : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 12m, 3m, 4m };
        yield return new object[] { -10m, 2m, -5m };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class DivisaoTests
{
    [Theory]
    [ClassData(typeof(CasosDeDivisao))]
    public void Divisao_DeveRetornarResultadoEsperado(
        decimal valor1,
        decimal valor2,
        decimal esperado)
    {
        decimal resultado = Calculadora.Divisao(valor1, valor2);

        Assert.Equal(esperado, resultado);
    }
}
```

## 4. `TheoryData`

`TheoryData<T...>` permite declarar os dados de um teste com tipos explícitos, evitando arrays de objetos. Ele pode ser usado como fonte de dados com `[MemberData]`. Neste exemplo, crie três cenários tipados para soma.

```csharp
using Xunit;

namespace CalculadoraConsole.Tests;

public class SomaComTheoryDataTests
{
    public static TheoryData<decimal, decimal, decimal> CasosDeSoma =>
        new()
        {
            { 2m, 3m, 5m },
            { -4m, 6m, 2m },
            { 0m, 7m, 7m }
        };

    [Theory]
    [MemberData(nameof(CasosDeSoma))]
    public void Soma_DeveRetornarResultadoEsperado(
        decimal valor1,
        decimal valor2,
        decimal esperado)
    {
        decimal resultado = Calculadora.Soma(valor1, valor2);

        Assert.Equal(esperado, resultado);
    }
}
```

## 5. Fixture

Uma fixture permite compartilhar um contexto entre os testes de uma classe. O xUnit cria a fixture e a fornece pelo construtor da classe de testes. Como `Calculadora` é estática e não precisa de preparação ou limpeza, este exemplo usa a fixture apenas para compartilhar os valores de um cenário; em testes reais, fixtures são mais úteis quando há recursos compartilhados que precisam de configuração e limpeza.

```csharp
using Xunit;

namespace CalculadoraConsole.Tests;

public class CalculadoraFixture
{
    public decimal Valor1 { get; } = 2m;
    public decimal Valor2 { get; } = 3m;
    public decimal SomaEsperada { get; } = 5m;
    public decimal MultiplicacaoEsperada { get; } = 6m;
}

public class SomaComFixtureTests : IClassFixture<CalculadoraFixture>
{
    private readonly CalculadoraFixture _fixture;

    public SomaComFixtureTests(CalculadoraFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Soma_DeveUsarOsValoresCompartilhadosPelaFixture()
    {
        decimal resultado = Calculadora.Soma(_fixture.Valor1, _fixture.Valor2);

        Assert.Equal(_fixture.SomaEsperada, resultado);
    }

    [Fact]
    public void Multiplicacao_DeveUsarOsValoresCompartilhadosPelaFixture()
    {
        decimal resultado = Calculadora.Multiplicacao(_fixture.Valor1, _fixture.Valor2);

        Assert.Equal(_fixture.MultiplicacaoEsperada, resultado);
    }
}
```

## Executar os testes

Depois de criar os exemplos, execute:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

## Revisão

Ao concluir, você terá praticado:

- passar casos diretamente com `[InlineData]`;
- fornecer dados a partir de um membro com `[MemberData]`;
- separar os dados em uma classe com `[ClassData]`;
- declarar dados de teoria com tipos explícitos usando `TheoryData`;
- compartilhar um contexto de teste com `IClassFixture<T>`.

Observe que `TheoryData` também pode ser fornecido por `[MemberData]`: `TheoryData` é uma forma tipada de declarar os dados, enquanto `MemberData` indica como o xUnit encontra esses dados.