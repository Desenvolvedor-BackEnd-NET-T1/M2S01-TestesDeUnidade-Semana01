using Xunit;

namespace CalculadoraConsole.Tests
{

    public class MultiplicacaoTest
    {
        public static IEnumerable<object[]> MultiplicacaoTestData =>
         new List<object[]>
         {
                    new object[] { 5, 3, 15 },
                    new object[] { 10, 5, 50 },
                    new object[] { 0, 0, 0 }
         };

        [Theory]
        [MemberData(nameof(MultiplicacaoTestData))]
        public void Multiplicacao_DeveMultiplicarDoisValores(decimal valor1, decimal valor2, decimal resultadoEsperado)
        {
            //Act
            decimal resultado = Calculadora.Multiplicacao(valor1, valor2);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }  

    }
}