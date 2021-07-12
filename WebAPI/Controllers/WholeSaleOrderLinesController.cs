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
    public class WholeSaleOrderLinesController : ControllerBase
    {
        private readonly IWholeSaleOrderLineService _wholeSaleOrderLineService;

        public WholeSaleOrderLinesController(IWholeSaleOrderLineService wholeSaleOrderLineService)
        {
            _wholeSaleOrderLineService = wholeSaleOrderLineService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _wholeSaleOrderLineService.GetAllWholeSaleOrderLines();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("wholeSaleOrderId/{id}")]
        public IActionResult GetByWholeSaleOrderId(int id)
        {
            var result = _wholeSaleOrderLineService.GetByWholeSaleOrderIdWholeSaleOrderLines(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
