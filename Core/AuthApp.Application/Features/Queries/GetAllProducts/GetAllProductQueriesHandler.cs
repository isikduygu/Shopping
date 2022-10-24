using AuthApp.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQueriesHandler : IRequestHandler<GetAllProductQueriesRequest, GetAllProductQueriesResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueriesHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetAllProductQueriesResponse> Handle(GetAllProductQueriesRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productReadRepository.GetAll().Count();
            var products = _productReadRepository.GetAll().Skip(request.Page * request.Size).Take(request.Size)
                .Include(products => products.ProductImageFiles)
                .Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.ProductImageFiles
            }).ToList();
            return new()
            {
                Products = products,
                TotalCount = totalCount
            };
        }
    }
}
// controllerda yaptığımız uygulamayı CQRS patternla buraya taşıdık. Request ve Handler classlarından IRequest ve IRequestHandler
// mediatordan geldi onları kullandık. Requeste reponsu Handlera ise request ve repsonsu yazdık. Handler kısmında const oluşturduk.
// request kısmında parametreleri (pagination)
// response kısmında göndereceğimiz veriyi ekledik
// IProductReadRepository normalde  Repositories katmanında onu da çektik. IOC katmanı sayesinde erişebiliyoruz.