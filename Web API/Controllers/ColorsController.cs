﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorService.Delete(color);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(Color color)
        {
            var result = _colorService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

    }
}
