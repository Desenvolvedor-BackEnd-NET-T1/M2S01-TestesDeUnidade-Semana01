using System.Globalization;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Escolha a operação:");
		Console.WriteLine("1 - Soma");
		Console.WriteLine("2 - Subtração");
		Console.WriteLine("3 - Multiplicação");
		Console.WriteLine("4 - Divisão");
		Console.Write("Opção: ");

		string? operacaoEscolhida = Console.ReadLine();
		string operacao = ConverterParaOperacao(operacaoEscolhida);

		Console.Write("Informe o primeiro valor: ");
		string? valor1Entrada = Console.ReadLine();
		Console.Write("Informe o segundo valor: ");
		string? valor2Entrada = Console.ReadLine();

		const NumberStyles estilosNumericos = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
		decimal valor1;
		decimal valor2;

		if (string.IsNullOrWhiteSpace(operacao)
			|| !decimal.TryParse(valor1Entrada, estilosNumericos, CultureInfo.InvariantCulture, out valor1)
			|| !decimal.TryParse(valor2Entrada, estilosNumericos, CultureInfo.InvariantCulture, out valor2))
		{
			Console.Error.WriteLine("Entrada inválida. Selecione uma operação válida e informe dois valores numéricos.");
			Environment.ExitCode = 1;
			return;
		}

		try
		{
			decimal resultado = Calculadora.Calcular(operacao, valor1, valor2);
			Console.WriteLine($"Resultado: {resultado.ToString(CultureInfo.InvariantCulture)}");
		}
		catch (ArgumentException exception)
		{
			Console.Error.WriteLine(exception.Message);
			Environment.ExitCode = 1;
		}
		catch (DivideByZeroException exception)
		{
			Console.Error.WriteLine(exception.Message);
			Environment.ExitCode = 1;
		}
	}

	private static string ConverterParaOperacao(string? operacaoEscolhida)
	{
		if (string.IsNullOrWhiteSpace(operacaoEscolhida))
		{
			return string.Empty;
		}

		return operacaoEscolhida.Trim().ToUpperInvariant() switch
		{
			"1" or "SOMA" => "SOMA",
			"2" or "SUBTRACAO" => "SUBTRACAO",
			"3" or "MULTIPLICACAO" => "MULTIPLICACAO",
			"4" or "DIVISAO" => "DIVISAO",
			_ => string.Empty,
		};
	}
}
