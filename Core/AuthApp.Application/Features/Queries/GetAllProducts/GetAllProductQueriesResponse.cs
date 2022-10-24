using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQueriesResponse
    {
        public object Products { get; set; }
        public int TotalCount { get; set; }
    }
}
