using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost("AddOrder")]

        public IActionResult Post(Order order)
        {
            var result = _orderService.Add(order);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpDelete("Delete Order By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _orderService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        
        [HttpPut("UpdateOrder")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllOrder")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByIdOrder")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
