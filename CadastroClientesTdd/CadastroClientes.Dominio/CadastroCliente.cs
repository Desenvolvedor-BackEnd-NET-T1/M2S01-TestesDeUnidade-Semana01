using System;
using System.Collections.Generic;

namespace CadastroClientes.Dominio
{
    public class CadastroCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public IReadOnlyList<Cliente> Listar()
        {
            return _clientes.AsReadOnly();
        }

        public void Cadastrar(string nome, string email, int idade)
        {
            Cliente cliente = new Cliente(nome, email, idade);

            foreach (Cliente clienteExistente in _clientes)
            {
                if (string.Equals(clienteExistente.Email, cliente.Email, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("E-mail já cadastrado.");
                }
            }

            _clientes.Add(cliente);
        }
    }
}
