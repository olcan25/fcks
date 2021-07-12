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
    public class WholeSaleOrdersController : ControllerBase
    {
        private readonly IWholeSaleOrderService _wholeSaleOrderService;

        public WholeSaleOrdersController(IWholeSaleOrderService wholeSaleOrderService)
        {
            _wholeSaleOrderService = wholeSaleOrderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _wholeSaleOrderService.GetAllWholeSaleOrdersDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _wholeSaleOrderService.GetByIdWholeSaleOrderDto(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("ledgerId/{ledgerId}")]
        public IActionResult GetByLedgerId(long ledgerId)
        {
            var result = _wholeSaleOrderService.GetByLedgerIdWholeSaleOrder(ledgerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("detail/id")]
        public IActionResult GetByIdDetail(int id)
        {
            var result = _wholeSaleOrderService.GetByIdWholeSaleOrder(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
