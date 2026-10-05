# Exercício Guiado M2S01

Este guia tem como objetivo orientar a criação do primeiro exercício prático do módulo: replicar a estrutura e a lógica de testes unitários para a classe `Calculadora`.

## Objetivo

Você deve criar um projeto de testes xUnit para testar a aplicação de calculadora e validar as operações de soma, subtração, multiplicação e divisão.

## 1. Criar o projeto de testes xUnit

Se o projeto de testes ainda não existir, execute o comando abaixo na raiz do repositório:

```bash
dotnet new xunit --name CalculadoraConsole.Tests --output CalculadoraConsole.Tests --framework net10.0
```

Esse comando cria uma estrutura inicial de testes com o framework xUnit.

## 2. Adicionar o projeto de testes à solução

Inclua o projeto de testes na solução da calculadora:

```bash
dotnet sln Calculadora.sln add CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

## 3. Adicionar referência ao projeto da calculadora

Agora, conecte o projeto de teste ao projeto principal da aplicação para que a classe `Calculadora` possa ser acessada pelos testes:

```bash
dotnet add CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj reference CalculadoraConsole/CalculadoraConsole.csproj
```

## 4. Verificar se a referência foi criada corretamente

Abra o arquivo `.csproj` do projeto de testes e confirme se existe uma referência ao projeto da calculadora.

## 5. Executar a build do projeto de testes

Compile o projeto de testes e a referência da calculadora:

```bash
dotnet build CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Se tudo estiver correto, a build deve terminar sem erros.

## 6. Executar os testes

Para rodar os testes criados, use:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

## 7. Primeiro teste unitário: Soma

No projeto xUnit criado acima, substitua o conteúdo do arquivo `CalculadoraConsole.Tests/UnitTest1.cs` pelo exemplo abaixo:

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

## 8. Rodar o teste individual

Depois de salvar o arquivo, execute:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Se o teste estiver correto, a saída no terminal deve indicar sucesso.

## 9. Próximo passo

Repita esse mesmo padrão para criar testes das outras operações:

- subtração
- multiplicação
- divisão

Crie um teste para cada método público da classe `Calculadora` e valide o resultado esperado em cada caso.

## Dica

Procure manter nomes de testes claros e objetivos, por exemplo:

- `Soma_DeveSomarDoisValores()`
- `Subtracao_DeveSubtrairDoisValores()`
- `Multiplicacao_DeveMultiplicarDoisValores()`
- `Divisao_DeveDividirDoisValores()`

## Objetivo final

Ao final deste exercício, você deve ter:

- um projeto de testes xUnit configurado;
- referência correta ao projeto da calculadora;
- testes automatizados para as operações matemáticas;
- execução bem-sucedida com `dotnet test`.
