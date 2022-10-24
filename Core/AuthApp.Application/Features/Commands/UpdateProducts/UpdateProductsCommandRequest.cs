using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.UpdateProducts
{
    public class UpdateProductsCommandRequest : IRequest<UpdateProductsCommandResponse>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }
    }
}
