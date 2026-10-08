using Xunit;

namespace CalculadoraConsole.Tests
{
    public class SomaTest
    {
        public static IEnumerable<object[]> SomaTestData =>
         new List<object[]>
         {
                    new object[] { 5, 3, 8 },
                    new object[] { 10, 5, 15 },
                    new object[] { 0, 0, 0 }
         };

        [Theory]
        [MemberData(nameof(SomaTestData))]
        public void Soma_DeveSomarDoisValores(decimal valor1, decimal valor2, decimal resultadoEsperado)
        {
            //Act
            decimal resultado = Calculadora.Soma(valor1, valor2);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [ClassData(typeof(FonteDados))]
        public void Soma_DeveSomarDoisValoresA(MassaDeDados dados)
        {
            //Act
            decimal resultado = Calculadora.Soma(dados.Valor1, dados.Valor2);

            // Assert
            Assert.Equal(dados.SomaEsperada, resultado);
        }

    }
}