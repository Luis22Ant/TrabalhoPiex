using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class UnauthorizedAccess : ApiPiexException
    {
        public UnauthorizedAccess(string message) : base(message)
        {

        }
    }
}
