using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgersController : ControllerBase
    {
        private readonly ILedgerService _ledgerService;

        public LedgersController(ILedgerService ledgerService)
        {
            _ledgerService = ledgerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ledgerService.GetAllLedgers();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("id/{id}")]
        public IActionResult GetById(long id)
        {
            var result = _ledgerService.GetByIdLedger(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("purchase/{id}")]
        public IActionResult GetLedgerPurchase(long id)
        {
            var result = _ledgerService.GetLedgerWithPurchase(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("wholesale/{id}")]
        public IActionResult GetLedgerWithWholeSale(long id)
        {
            var result = _ledgerService.GetLedgerWithWholeSale(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
