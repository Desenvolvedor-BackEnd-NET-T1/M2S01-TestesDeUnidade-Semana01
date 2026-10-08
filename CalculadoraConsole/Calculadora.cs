public static class Calculadora
{
    public static decimal Calcular(string operacao, decimal valor1, decimal valor2)
    {
        string operacaoNormalizada = operacao.Trim().ToUpperInvariant();

        switch (operacaoNormalizada)
        {
            case "SOMA":
                return Soma(valor1, valor2);

            case "SUBTRACAO":
                return Subtracao(valor1, valor2);

            case "MULTIPLICACAO":
                return Multiplicacao(valor1, valor2);

            case "DIVISAO":
                return Divisao(valor1, valor2);

            default:
                throw new ArgumentException("Operação inválida.", nameof(operacao));
        }
    }

    public static decimal Soma(decimal valor1, decimal valor2)
    {
        try
        {
            if (valor1 < 0 || valor2 < 0)
            {
                throw new ArgumentException("Valores não podem ser negativos.");
            }

            return valor1 + valor2;
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro na soma: " + ex.Message);
        }
    }

    public static decimal Subtracao(decimal valor1, decimal valor2)
    {
        return valor1 - valor2;
    }

    public static decimal Multiplicacao(decimal valor1, decimal valor2)
    {
        return valor1 * valor2;
    }

    public static decimal Divisao(decimal valor1, decimal valor2)
    {
        return valor1 / valor2;
    }
}