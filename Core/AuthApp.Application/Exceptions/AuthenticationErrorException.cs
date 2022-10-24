using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Exceptions
{
    public class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException() : base("Failed Authentication")
        {

        }

        public AuthenticationErrorException(string? message) : base(message)
        {
        }
        public AuthenticationErrorException(string message, Exception inner) : base(message, inner) { }
    }
}
