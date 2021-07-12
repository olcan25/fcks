using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerBankAccountsController : ControllerBase
    {
        private readonly IPartnerBankAccountService _partnerBankAccountService;

        public PartnerBankAccountsController(IPartnerBankAccountService partnerBankAccountService)
        {
            _partnerBankAccountService = partnerBankAccountService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _partnerBankAccountService.GetAllDtoPartnerBankAccounts();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _partnerBankAccountService.GetByIdDtoPartnerBankAccount(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(PartnerBankAccount partnerBankAccount)
        {
            var result = _partnerBankAccountService.AddPartnerBankAccount(partnerBankAccount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var partnerBankAccount = _partnerBankAccountService.GetForDelete(id).Data;
            var result = _partnerBankAccountService.DeletePartnerBankAccount(partnerBankAccount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(PartnerBankAccount partnerBankAccount)
        {
            var result = _partnerBankAccountService.UpdatePartnerBankAccount(partnerBankAccount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
