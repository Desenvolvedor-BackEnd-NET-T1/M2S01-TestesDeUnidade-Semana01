using System;
using CadastroClientes.Dominio;
using Xunit;

namespace CadastroClientes.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void CriarCliente_ComDadosValidos_DeveGuardarOsDados()
        {
            Cliente cliente = new Cliente("Ana Silva", "ana@email.com", 25);

            Assert.Equal("Ana Silva", cliente.Nome);
            Assert.Equal("ana@email.com", cliente.Email);
            Assert.Equal(25, cliente.Idade);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CriarCliente_ComNomeAusente_DeveRejeitar(string? nome)
        {
            Assert.Throws<ArgumentException>(() => new Cliente(nome!, "ana@email.com", 25));
        }

        [Theory]
        [InlineData("A")]
        [InlineData("Al")]
        public void CriarCliente_ComNomeCurto_DeveRejeitar(string nome)
        {
            Assert.Throws<ArgumentException>(() => new Cliente(nome, "ana@email.com", 25));
        }

        [Fact]
        public void CriarCliente_ComNomeAcimaDoLimite_DeveRejeitar()
        {
            string nome = new string('A', 101);

            Assert.Throws<ArgumentException>(() => new Cliente(nome, "ana@email.com", 25));
        }

        [Fact]
        public void CriarCliente_ComEspacosNasExtremidades_DeveNormalizarNome()
        {
            Cliente cliente = new Cliente("  Ana Silva  ", "ana@email.com", 25);

            Assert.Equal("Ana Silva", cliente.Nome);
        }

        [Fact]
        public void CriarCliente_ComNomeComTresCaracteres_DeveAceitar()
        {
            Cliente cliente = new Cliente("Ana", "ana@email.com", 25);
            Assert.Equal("Ana", cliente.Nome);
        }

        [Fact]
        public void CriarCliente_ComNomeComCemCaracteres_DeveAceitar()
        {
            string nome = new string('A', 100);
            Cliente cliente = new Cliente(nome, "ana@email.com", 25);

            Assert.Equal(nome, cliente.Nome);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("ana.email.com")]
        [InlineData("@email.com")]
        [InlineData("ana@")]
        [InlineData("ana@@email.com")]
        [InlineData("ana silva@email.com")]
        public void CriarCliente_ComEmailInvalido_DeveRejeitar(string? email)
        {
            Assert.Throws<ArgumentException>(() => new Cliente("Ana Silva", email!, 25));
        }

        [Fact]
        public void CriarCliente_ComEmailComEspacosNasExtremidades_DeveNormalizarEmail()
        {
            Cliente cliente = new Cliente("Ana Silva", "  ana@email.com  ", 25);

            Assert.Equal("ana@email.com", cliente.Email);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(17)]
        [InlineData(121)]
        public void CriarCliente_ComIdadeInvalida_DeveRejeitar(int idade)
        {
            Assert.Throws<ArgumentException>(() => new Cliente("Ana Silva", "ana@email.com", idade));
        }

        [Theory]
        [InlineData(18)]
        [InlineData(25)]
        [InlineData(120)]
        public void CriarCliente_ComIdadeValida_DeveAceitar(int idade)
        {
            Cliente cliente = new Cliente("Ana Silva", "ana@email.com", idade);
            Assert.Equal(idade, cliente.Idade);
        }
    }
}
