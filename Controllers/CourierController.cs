using LarekApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LarekApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController : Controller
    {
        private readonly ICourier _courierService;

        public CourierController(ICourier courierService)
        {
            _courierService = courierService;
        }

        [HttpGet("СollectTheOrder")]
        public async Task CollectOrder()
        {
            //??
        }
    }
}
