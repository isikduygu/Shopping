using AuthApp.Application.Repositories;
using AuthApp.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Commands.UpdateProducts
{ 
    public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsCommandRequest, UpdateProductsCommandResponse>
    {
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

        public UpdateProductsCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<UpdateProductsCommandResponse> Handle(UpdateProductsCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetByIdAsync(request.Id);
            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            await _productWriteRepository.SaveAsync();
            return new();
        }
    }
}
