using System;

namespace CadastroClientes.Dominio
{
    public class Cliente
    {
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public int Idade { get; private set; }

        public Cliente(string nome, string email, int idade)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome é obrigatório.", nameof(nome));
            }

            string nomeNormalizado = nome.Trim();
            if (nomeNormalizado.Length < 3 || nomeNormalizado.Length > 100)
            {
                throw new ArgumentException("Nome deve ter entre 3 e 100 caracteres.", nameof(nome));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("E-mail é obrigatório.", nameof(email));
            }

            string emailNormalizado = email.Trim();
            if (emailNormalizado.Contains(' ') || emailNormalizado.Contains('\t') || emailNormalizado.Contains('\r') || emailNormalizado.Contains('\n'))
            {
                throw new ArgumentException("E-mail inválido.", nameof(email));
            }

            int posArroba = emailNormalizado.IndexOf('@');
            int ultimaArroba = emailNormalizado.LastIndexOf('@');

            if (posArroba <= 0 || ultimaArroba != posArroba || ultimaArroba == emailNormalizado.Length - 1)
            {
                throw new ArgumentException("E-mail inválido.", nameof(email));
            }

            string antesArroba = emailNormalizado.Substring(0, posArroba);
            string depoisArroba = emailNormalizado.Substring(posArroba + 1);

            if (string.IsNullOrEmpty(antesArroba) || string.IsNullOrEmpty(depoisArroba))
            {
                throw new ArgumentException("E-mail inválido.", nameof(email));
            }

            if (antesArroba.IndexOfAny(new[] { ' ', '\t', '\r', '\n' }) >= 0 || depoisArroba.IndexOfAny(new[] { ' ', '\t', '\r', '\n' }) >= 0)
            {
                throw new ArgumentException("E-mail inválido.", nameof(email));
            }

            if (idade < 18 || idade > 120)
            {
                throw new ArgumentException("Idade deve estar entre 18 e 120 anos.", nameof(idade));
            }

            Nome = nomeNormalizado;
            Email = emailNormalizado;
            Idade = idade;
        }
    }
}
