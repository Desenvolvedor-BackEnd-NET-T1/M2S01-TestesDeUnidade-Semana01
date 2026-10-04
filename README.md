# Calculadora Console

Aplicação de console em .NET 10 com operações de soma, subtração, multiplicação e divisão. A lógica de cada operação está disponível em métodos públicos da classe `Calculadora`, permitindo testá-los sem interagir com o console.

## 1. Executar localmente

É necessário ter o SDK do .NET 10 instalado. Na raiz do repositório, execute:

```bash
dotnet run --project CalculadoraConsole
```

O programa lê três linhas, nesta ordem:

1. Operação: `Soma`, `Subtracao`, `Multiplicacao` ou `Divisao`.
2. Primeiro valor (`Valor1`).
3. Segundo valor (`Valor2`).

Os nomes das operações não diferenciam maiúsculas de minúsculas. Use ponto como separador decimal. O programa não exibe prompts: depois das três linhas, escreve o resultado no console.

Exemplo de interação:

```text
Soma
10
5
```

Resultado:

```text
15
```

Também é possível enviar a entrada por pipe:

```bash
printf 'Soma\n10\n5\n' | dotnet run --project CalculadoraConsole
```

## 2. Criar e configurar um projeto xUnit

Se o projeto de testes ainda não existir, execute os comandos a seguir uma vez na raiz do repositório. Se já existir, pule a criação e a referência e vá direto para o build.

Crie um projeto xUnit:

```bash
dotnet new xunit --name CalculadoraConsole.Tests --output CalculadoraConsole.Tests --framework net10.0
```

Adicione uma referência ao projeto da calculadora. Isso permite que os testes acessem a classe pública `Calculadora`:

```bash
dotnet add CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj reference CalculadoraConsole/CalculadoraConsole.csproj
```

Compile o projeto de testes e a referência da calculadora:

```bash
dotnet build CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

Para executar os testes:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```

## 3. Primeiro teste unitário: Soma

No projeto xUnit criado acima, substitua o conteúdo do arquivo `CalculadoraConsole.Tests/UnitTest1.cs` pelo exemplo abaixo. O teste chama `Calculadora.Soma` diretamente e compara o resultado esperado com o obtido, sem iniciar a aplicação de console.

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

Execute o teste com:

```bash
dotnet test CalculadoraConsole.Tests/CalculadoraConsole.Tests.csproj
```
