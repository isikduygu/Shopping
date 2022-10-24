using AuthApp.Domain.Entitites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites
{
    public class Product : BaseEntities
    {
        public string Name { get; set;}
        public float Price { get; set; }
        public int Stock { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
