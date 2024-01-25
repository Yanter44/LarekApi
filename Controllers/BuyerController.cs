using LarekApi.DtoS;
using LarekApi.Entityes;
using LarekApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LarekApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
      private readonly IBuyerService _buyerService;

       public BuyerController(IBuyerService buyerService)
        {
           _buyerService = buyerService;
        }
        [HttpGet("GetProduct")]
        public async Task<ActionResult<string>> FindProduct(string productName)
        {

           var product = await _buyerService.FindProduct(productName);
            return Ok(product);
        }
        [HttpPost("OrderProducts")]
        public async Task<ActionResult> MyOrder([FromForm]OrderDto order)
        {
            var zakaz = _buyerService.OrderProduct(order);
            return Ok(zakaz.Result);
        }
        [HttpPost("CanselProduct")]
        public async Task<ActionResult> CanselOrder(string OrderId)
        {
            var deletedOrder = _buyerService.CancelProduct(OrderId);
            return Ok(deletedOrder.Result);
        }
    }
}
