public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public bool ClienteValido()
    {

        if (!string.IsNullOrWhiteSpace(Nome) && !string.IsNullOrWhiteSpace(Email))
        {
            return true;
        }

        return false;
    }

    public bool CpfValido(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            return false;
        }

        // Implementar a lógica de validação do CPF aqui
        // Retornar true se o CPF for válido, caso contrário, retornar false

        return true; // Placeholder para fins de exemplo
    }

}