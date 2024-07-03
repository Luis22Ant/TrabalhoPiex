using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProjetoIntegrador.Infra.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a descrição!")]
        [StringLength(200)]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a quantidade!")]
        public int Quantidade { get; set; }
        public DateTime DataDoacao { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Guid CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        [ForeignKey(nameof(DoadorId))]
        public Guid DoadorId { get; set; }

        [JsonIgnore]
        public Doador? Doador { get; set; }

        public void DiminuirItem(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }
}

