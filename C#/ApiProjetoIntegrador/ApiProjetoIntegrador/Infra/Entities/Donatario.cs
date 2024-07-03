using System.ComponentModel.DataAnnotations;

namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Donatario 
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF!")]
        [StringLength(11)]
        public string Cpf { get; set; } = string.Empty;
        public ICollection<ItemDoado> Items { get; set; } = new List<ItemDoado>();
    }
}
