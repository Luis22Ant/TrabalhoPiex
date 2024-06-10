using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPiex.Infra.Models
{
    public class Doador
    {
        public Guid id { get; set; }
        public string Nome { get; set; } = "";
        public string Cpf { get; set; } = "";
        public string Data { get; set; } = "";
        public string Item { get; set; } = "";
    }
}
