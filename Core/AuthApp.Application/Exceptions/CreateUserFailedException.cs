using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Exceptions
{
    public class CreateUserFailedException : Exception
    {
        public CreateUserFailedException() : base("Failed")
        {

        }
    }
}
