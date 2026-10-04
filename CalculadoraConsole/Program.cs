using System.Globalization;

public class Program
{
	public static void Main()
	{
		string? operacao = Console.ReadLine();
		string? valor1Entrada = Console.ReadLine();
		string? valor2Entrada = Console.ReadLine();

		const NumberStyles estilosNumericos = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
		decimal valor1;
		decimal valor2;

		if (string.IsNullOrWhiteSpace(operacao)
			|| !decimal.TryParse(valor1Entrada, estilosNumericos, CultureInfo.InvariantCulture, out valor1)
			|| !decimal.TryParse(valor2Entrada, estilosNumericos, CultureInfo.InvariantCulture, out valor2))
		{
			Console.Error.WriteLine("Entrada inválida. Informe a operação e dois valores numéricos.");
			Environment.ExitCode = 1;
			return;
		}

		try
		{
			decimal resultado = Calculadora.Calcular(operacao, valor1, valor2);
			Console.WriteLine(resultado.ToString(CultureInfo.InvariantCulture));
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
}
