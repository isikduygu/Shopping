using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites
{
    public class Order : BaseEntities
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
