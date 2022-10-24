using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Queries.GetByIdProducts
{
    public class GetByIdQueriesResponse
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
