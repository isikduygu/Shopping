using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites.Identity
{
    public class AppUser : IdentityUser
    {
        public string NameSurname { get; set; }
    }
}
