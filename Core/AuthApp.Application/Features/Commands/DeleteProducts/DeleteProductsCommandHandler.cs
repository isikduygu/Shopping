using AuthApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.DeleteProducts
{
    public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommandRequest, DeleteProductsCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public DeleteProductsCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductsCommandResponse> Handle(DeleteProductsCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
