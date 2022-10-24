using AuthApp.Application.Repositories;
using AuthApp.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Queries.GetByIdProducts
{
    public class GetByIdQueriesHandler : IRequestHandler<GetByIdQueriesRequest, GetByIdQueriesResponse>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetByIdQueriesHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdQueriesResponse> Handle(GetByIdQueriesRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
