using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Exceptions
{
    public class InvalidPasswordOrEmailException : Exception
    {
        public InvalidPasswordOrEmailException() : base("Invalid password or email")
        {

        }

        public InvalidPasswordOrEmailException(string? message) : base(message)
        {
        }
    }
}
