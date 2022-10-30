using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites
{
    public class Customer : BaseEntities
    {
        public string Name { get; set; }
    }
}
