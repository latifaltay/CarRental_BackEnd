using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Car car)
        {
            var result = _carService.Add(car);
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Car car)
        {
            var result = _carService.Delete(car);
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Car car)
        {
            var result = _carService.Update(car);
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId([FromQuery] int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId([FromQuery] int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.IsSuccess)
            {
                return Ok(result);  
            }
            return BadRequest(result); 
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _carService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }
    }
}
