using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.NssJWT_Core
{
    public class JwtException : Exception
    {
        public JwtException(string message)
            : base(message)
        {
        }

        public JwtException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
