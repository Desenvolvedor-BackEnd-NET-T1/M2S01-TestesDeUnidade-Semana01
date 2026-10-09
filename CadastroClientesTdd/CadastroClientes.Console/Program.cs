using System;
using CadastroClientes.Dominio;

namespace CadastroClientes.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CadastroCliente cadastro = new CadastroCliente();
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("0 - Sair");
                string opcao = Console.ReadLine() ?? string.Empty;

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente(cadastro);
                        break;
                    case "2":
                        ListarClientes(cadastro);
                        break;
                    case "0":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private static void CadastrarCliente(CadastroCliente cadastro)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.Write("E-mail: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Idade: ");
            string entradaIdade = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(entradaIdade, out int idade))
            {
                Console.WriteLine("Informe um número inteiro para a idade.");
                return;
            }

            try
            {
                cadastro.Cadastrar(nome, email, idade);
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (ArgumentException erro)
            {
                Console.WriteLine(erro.Message);
            }
            catch (InvalidOperationException erro)
            {
                Console.WriteLine(erro.Message);
            }
        }

        private static void ListarClientes(CadastroCliente cadastro)
        {
            if (cadastro.Listar().Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in cadastro.Listar())
            {
                Console.WriteLine($"{cliente.Nome} | {cliente.Email} | {cliente.Idade} anos");
            }
        }
    }
}
