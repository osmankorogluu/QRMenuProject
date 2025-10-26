using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService=orderService;
        }
    
    [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var result = _orderService.TTotalOrderCount();
            return Ok(result);

        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var result = _orderService.TTotalOrderCount();
            return Ok(result);

        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok( _orderService.TLasOrderPrice());

        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok( _orderService.TTodayTotalPrice());
        }
    }
}
