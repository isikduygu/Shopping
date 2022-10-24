
using AuthApp.Application.Abstraction.Storage;
using AuthApp.Application.Features.Commands.CreateProducts;
using AuthApp.Application.Features.Commands.DeleteProducts;
using AuthApp.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using AuthApp.Application.Features.Commands.ProductImageFile.UploadProductImage;
using AuthApp.Application.Features.Commands.UpdateProducts;
using AuthApp.Application.Features.Queries.GetAllProducts;
using AuthApp.Application.Features.Queries.GetByIdProducts;
using AuthApp.Application.Features.Queries.ProductImageFile.GetProductImages;
using AuthApp.Application.Repositories;
using AuthApp.Application.RequestParameters;
using AuthApp.Domain.Entitites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AuthApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;
        readonly IStorageService _storageService;

        public ProductsController(
            IMediator mediator, IStorageService storageService)
        {
            _mediator = mediator;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueriesRequest getAllProductQueriesRequest)
        {
            GetAllProductQueriesResponse response = await _mediator.Send(getAllProductQueriesRequest);
            return Ok(response);
        }

        // mediator ile istek paptık. daha sonra gapqRequest türünde bi değişken oluşturup meditor ile gönderdik. 
        // gelen işlemi de gapqResponse türünde bi değişkende tutup responsu döndürdük.

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdQueriesRequest getByIdQueriesRequest)
        {
           GetByIdQueriesResponse response = await _mediator.Send(getByIdQueriesRequest);
            return Ok(response);
        }
        // FROMROUTE amacı idnin routerdan geldiğini belirtmek.
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put(UpdateProductsCommandRequest updateProductCommandRequest)
        {
            UpdateProductsCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductsCommandRequest deleteProductsCommandRequest)
        {
            DeleteProductsCommandResponse response =await _mediator.Send(deleteProductsCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            uploadProductImageCommandRequest.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            //Ders sonrası not !
            //Burada RemoveProductImageCommandRequest sınıfı içerisindeki ImageId property'sini de 'FromQuery' attribute'u ile işaretleyebilirdik!

            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
            return Ok();
        }


        //private readonly IProductService _productService; // talep ediyoruz

        //public ProductsController(IProductService productService) // otomatik üretiyoruz
        //{
        //    _productService = productService; // concretedeki nesne gelecektir
        //}

        //// GET: api/<ProductsController>
        //[HttpGet] // Actionlara tür bildirmek gerek
        //public IActionResult GetProducts()
        //{
        //    var products = _productService.GetProducts();
        //    return Ok(products);
        //}

    }
}
