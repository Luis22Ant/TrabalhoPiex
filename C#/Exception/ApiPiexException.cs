using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class ApiPiexException : System.Exception
    {
        public ApiPiexException(string message) : base(message)
        {

        }
    }
}
