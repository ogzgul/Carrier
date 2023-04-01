using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationsController : ControllerBase
    {
        ICarrierConfigurationService _carrierConfigurationService;

        public CarrierConfigurationsController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }


        [HttpPost]

        public IActionResult Post(CarrierConfiguration carrierConfiguration)
        {
            var result = _carrierConfigurationService.Add(carrierConfiguration);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpDelete("Delete CarrierConfiguration By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _carrierConfigurationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

       
        [HttpPut("Update")]
        public IActionResult Update(CarrierConfiguration carrierConfiguration)
        {
            var result = _carrierConfigurationService.Update(carrierConfiguration);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carrierConfigurationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carrierConfigurationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

