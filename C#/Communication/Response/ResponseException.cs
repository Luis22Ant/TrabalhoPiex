using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPiex.Communication.Response
{
    public class ResponseException
    {
        public string Message { get; set; } = string.Empty;

        public ResponseException(string message)
        {
            Message = message;
        }
    }
}
