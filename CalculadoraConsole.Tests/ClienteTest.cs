using Xunit;

namespace CalculadoraConsole.Tests
{
    public class ClienteTest
    {

        [Fact]
        public void TestarPropriedadesCliente()
        {

            var cliente = new Cliente(1, "João", "joao@email.com");

            Assert.True(cliente.ClienteValido());
        }

        [Fact]
        public void TestarCpfInvalido()
        {

            var cliente = new Cliente(1, "João", "joao@email.com");

            Assert.True(cliente.CpfValido(""));
        }

    }
}