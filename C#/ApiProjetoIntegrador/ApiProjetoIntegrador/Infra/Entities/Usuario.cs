using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF!")]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o Login!")]
        [StringLength(20)]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha!")]
        [StringLength(15)]
        public string Senha { get; set; } = string.Empty;

        public Role Role { get; set; }


    }

    public enum Role
    {
        Admin,
        Usuario
    }
}
