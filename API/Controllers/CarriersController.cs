using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        ICarrierService _carrierService;

        public CarriersController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }


        [HttpPost]

        public IActionResult Post(Carrier carrier)
        {
            var result = _carrierService.Add(carrier);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpDelete("Delete Carrier By Id")]

        public IActionResult DeleteById(int id)
        {
            var result=_carrierService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete("Delete Carrier By Name")]

        public IActionResult DeleteByName(string carrierName)
        {
            var result = _carrierService.DeleteByName(carrierName);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Carrier carrier)
        {
            var result = _carrierService.Update(carrier);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carrierService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carrierService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
