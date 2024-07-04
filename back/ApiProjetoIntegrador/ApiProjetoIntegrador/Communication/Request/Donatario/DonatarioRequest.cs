using System.ComponentModel.DataAnnotations;

namespace ApiProjetoIntegrador.Communication.Request.Donatario;

public class DonatarioRequest
{

    [Required(ErrorMessage = "Informe o nome!")]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o CPF!")]
    [StringLength(11)]
    public string Cpf { get; set; } = string.Empty;
}
