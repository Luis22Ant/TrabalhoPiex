using System.ComponentModel.DataAnnotations;

namespace ApiProjetoIntegrador.Communication.Request.Categoria
{
    public class CategoriaRequest
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;
    }
}
