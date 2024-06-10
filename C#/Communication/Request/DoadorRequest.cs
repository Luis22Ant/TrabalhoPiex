using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.Request
{
    public class DoadorRequest
    {
        public string Nome { get; set; } = "";
        public string Cpf { get; set; } = "";
        public string Data { get; set; } = "";
        public string itemDoado { get; set; } = "";
    }
}
