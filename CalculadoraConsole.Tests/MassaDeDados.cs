using Xunit;

namespace CalculadoraConsole.Tests
{

    public class MassaDeDados
    {
        public decimal Valor1 { get; set; }
        public decimal Valor2 { get; set; }

        public decimal SubtracaoEsperada { get; set; }

        public decimal SomaEsperada { get; set; }

        public decimal MultiplicacaoEsperada { get; set; }

    }

    public class FonteDados : TheoryData<MassaDeDados>
    {
        public FonteDados()
        {
            Add(new MassaDeDados { Valor1 = 5, Valor2 = 3, SomaEsperada = 8, SubtracaoEsperada = 2, MultiplicacaoEsperada = 15 });
            Add(new MassaDeDados { Valor1 = 10, Valor2 = 5, SomaEsperada = 15, SubtracaoEsperada = 5, MultiplicacaoEsperada = 50 });
            Add(new MassaDeDados { Valor1 = 0, Valor2 = 0, SomaEsperada = 0, SubtracaoEsperada = 0, MultiplicacaoEsperada = 0 });
        }
    }

}