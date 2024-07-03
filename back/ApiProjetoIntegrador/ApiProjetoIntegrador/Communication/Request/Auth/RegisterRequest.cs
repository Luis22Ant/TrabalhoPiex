using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Communication.Request.Auth
{
    public class RegisterRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public Role Role { get; set; }

    }
}
