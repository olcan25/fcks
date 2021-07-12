using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract.Service;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _partnerService.GetAllPartners();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _partnerService.GetByIdPartner(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Partner partner)
        {
            var result = _partnerService.AddPartner(partner);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var partner = _partnerService.GetByIdPartner(id).Data;
            var result = _partnerService.DeletePartner(partner);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(Partner partner)
        {
            var result = _partnerService.UpdatePartner(partner);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
