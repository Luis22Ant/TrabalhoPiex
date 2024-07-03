using System.ComponentModel.DataAnnotations;

namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
