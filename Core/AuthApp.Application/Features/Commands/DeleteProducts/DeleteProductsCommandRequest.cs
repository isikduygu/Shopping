using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.DeleteProducts
{
    public class DeleteProductsCommandRequest : IRequest<DeleteProductsCommandResponse>
    {
        public int Id { get; set; }
    }
}
