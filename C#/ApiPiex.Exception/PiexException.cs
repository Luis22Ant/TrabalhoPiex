using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPiex.Exception
{
    public class PiexException : SystemException
    {
        public PiexException(string message) : base(message)
        {

        }
    }
}
