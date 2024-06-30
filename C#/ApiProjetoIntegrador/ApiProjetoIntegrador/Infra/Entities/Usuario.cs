namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Usuario 
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public Role Role { get; set; }


    }

    public enum Role
    {
        Admin,
        Usuario
    }
}
