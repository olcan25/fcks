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
    public class PurchaseOrderLinesController : ControllerBase
    {
        private readonly IPurchaseOrderLineService _purchaseOrderLineService;

        public PurchaseOrderLinesController(IPurchaseOrderLineService purchaseOrderLineService)
        {
            _purchaseOrderLineService = purchaseOrderLineService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _purchaseOrderLineService.GetAllPurchaseOrderLines();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("purchaseOrderId/{id}")]
        public IActionResult GetByPurchaseOrderId(int id)
        {
            var result = _purchaseOrderLineService.GetByPurchaseOrderIdPurchaseOrderLines(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
