using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Queries.GetByIdProducts
{
    public class GetByIdQueriesRequest : IRequest<GetByIdQueriesResponse>
    {
        public int Id { get; set; }
    }
}
