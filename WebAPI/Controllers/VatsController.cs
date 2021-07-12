using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatsController : ControllerBase
    {
        private readonly IVatService _vatService;

        public VatsController(IVatService vatService)
        {
            _vatService = vatService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _vatService.GetAllVats();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(byte id)
        {
            var result = _vatService.GetByIdVat(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
