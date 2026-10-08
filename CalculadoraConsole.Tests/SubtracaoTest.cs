using Xunit;

namespace CalculadoraConsole.Tests
{
    public class SubtracaoTest
    {
        public static IEnumerable<object[]> SubtracaoTestData =>
         new List<object[]>
         {
                    new object[] { 5, 3, 2 },
                    new object[] { 10, 5, 5 },
                    new object[] { 0, 0, 0 }
         };

        [Theory]
        [MemberData(nameof(SubtracaoTestData))]
        public void Subtracao_DeveSubtrairDoisValores(decimal valor1, decimal valor2, decimal resultadoEsperado)
        {
            //Act
            decimal resultado = Calculadora.Subtracao(valor1, valor2);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [ClassData(typeof(FonteDados))]
        public void Subtracao_DeveSubtrairDoisValoresA(MassaDeDados dados)
        {
            //Act
            decimal resultado = Calculadora.Subtracao(dados.Valor1, dados.Valor2);

            // Assert
            Assert.Equal(dados.SubtracaoEsperada, Calculadora.Subtracao(dados.Valor1, dados.Valor2));
        }
    }
}