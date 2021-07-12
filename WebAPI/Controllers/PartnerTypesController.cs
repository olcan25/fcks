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
    public class PartnerTypesController : ControllerBase
    {
        private readonly IPartnerTypeService _partnerTypeService;

        public PartnerTypesController(IPartnerTypeService partnerTypeService)
        {
            _partnerTypeService = partnerTypeService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _partnerTypeService.GetAllPartnerTypes();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(byte id)
        {
            var result = _partnerTypeService.GetByIdPartnerType(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
