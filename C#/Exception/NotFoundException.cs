using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class NotFoundException : ApiPiexException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
