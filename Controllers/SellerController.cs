using LarekApi.Entityes;
using LarekApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MikesPaging.AspNetCore.Common.ViewModels;
using Newtonsoft.Json;

namespace LarekApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {

        private readonly IProductService _productService;
        private readonly ILogger<SellerController> _logger;
        public SellerController(IProductService productService, ILogger<SellerController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return Ok();
        }
        [HttpGet("GetCategories")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetCategories([FromQuery] PagingOptionsModel pagingOptionsModel)
        {
            try
            {
                _logger.LogInformation("Start processing GetCategories method.");
                var resultCategory = await _productService.GetCategories(pagingOptionsModel);
                return Ok(resultCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка в конечной точке GetCategories.");
                return StatusCode(500, "Внутренняя ошибка сервера");
            }
        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult> AddCategory(string categoryName)
        {
            await _productService.AddCategory(categoryName);
            return Ok();
        }

    }
}
