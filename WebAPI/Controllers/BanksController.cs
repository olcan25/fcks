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
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bankService.GetAllBanks();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(short id)
        {
            var result = _bankService.GetByIdBank(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(Bank bank)
        {
            var result = _bankService.AddBank(bank);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var bank = _bankService.GetByIdBank(id).Data;
            if (bank == null)
            {
                return BadRequest(bank);
            }

            var result = _bankService.DeleteBank(bank);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Bank bank)
        {
            var result = _bankService.UpdateBank(bank);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
