using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProjetoIntegrador.Communication.Request.ItemDoado
{
    public class ItemDoadoRequest
    {

        public Guid ItemId { get; set; }

        public Guid DonatarioId { get; set; }
        public DateTime DataDoacao { get; set; }

        [Required(ErrorMessage = "Informe a quantidade!")]
        public int Quantidade { get; set; }
    }
}
