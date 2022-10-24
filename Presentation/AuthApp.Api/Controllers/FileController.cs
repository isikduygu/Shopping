using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        readonly IConfiguration _configuration;

        public FileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetBaseUrl()
        {
            return Ok(_configuration["BaseStorageUrl"]);
        }
    }
}
