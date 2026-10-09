using System;
using CadastroClientes.Dominio;
using Xunit;

namespace CadastroClientes.Tests
{
    public class CadastroClienteTests
    {
        [Fact]
        public void Listar_SemClientes_DeveRetornarListaVazia()
        {
            CadastroCliente cadastro = new CadastroCliente();

            Assert.Empty(cadastro.Listar());
        }

        [Fact]
        public void Cadastrar_ComDadosValidos_DeveArmazenarCliente()
        {
            CadastroCliente cadastro = new CadastroCliente();

            cadastro.Cadastrar("Ana Silva", "ana@email.com", 25);

            Cliente cliente = Assert.Single(cadastro.Listar());
            Assert.Equal("Ana Silva", cliente.Nome);
            Assert.Equal("ana@email.com", cliente.Email);
            Assert.Equal(25, cliente.Idade);
        }

        [Fact]
        public void Cadastrar_ComDoisClientesDiferentes_DeveManterOsDoisNaLista()
        {
            CadastroCliente cadastro = new CadastroCliente();

            cadastro.Cadastrar("Ana Silva", "ana@email.com", 25);
            cadastro.Cadastrar("Bruno Costa", "bruno@email.com", 30);

            Assert.Collection(cadastro.Listar(),
                cliente =>
                {
                    Assert.Equal("Ana Silva", cliente.Nome);
                    Assert.Equal("ana@email.com", cliente.Email);
                    Assert.Equal(25, cliente.Idade);
                },
                cliente =>
                {
                    Assert.Equal("Bruno Costa", cliente.Nome);
                    Assert.Equal("bruno@email.com", cliente.Email);
                    Assert.Equal(30, cliente.Idade);
                });
        }

        [Theory]
        [InlineData("ana@email.com")]
        [InlineData("ANA@EMAIL.COM")]
        [InlineData("  ana@email.com  ")]
        public void Cadastrar_ComEmailDuplicado_DeveRejeitar(string email)
        {
            CadastroCliente cadastro = new CadastroCliente();
            cadastro.Cadastrar("Ana Silva", "ana@email.com", 25);

            Assert.Throws<InvalidOperationException>(() => cadastro.Cadastrar("Outra Pessoa", email, 30));
            Assert.Single(cadastro.Listar());
        }

        [Fact]
        public void Cadastrar_ComIdadeInvalida_NaoDeveAdicionarNaLista()
        {
            CadastroCliente cadastro = new CadastroCliente();

            Assert.Throws<ArgumentException>(() => cadastro.Cadastrar("Ana Silva", "ana@email.com", 17));
            Assert.Empty(cadastro.Listar());
        }
    }
}
