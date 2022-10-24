using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Entitites
{
    public class InvoiceFile : File
    {
        public decimal Price { get; set; }
    }
}
