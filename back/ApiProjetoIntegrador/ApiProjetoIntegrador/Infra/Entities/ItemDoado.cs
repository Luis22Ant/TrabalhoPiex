using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProjetoIntegrador.Infra.Entities
{
    public class ItemDoado
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ItemId))]
        public Guid ItemId { get; set; }

        [ForeignKey(nameof(DonatarioId))]
        public Guid DonatarioId { get; set; }

        [JsonIgnore]
        public Donatario? Donatario { get; set; }

        public DateTime DataDoacao { get; set; }

        [Required(ErrorMessage = "Informe a quantidade!")]
        public int Quantidade { get; set; }


    }
}
