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
    public class InvoiceLinesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceLinesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        
        [HttpGet()]
        public IActionResult GetAllInvoiceLines()
        {
            var result = _invoiceService.GetAllInvoiceLines();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        
        [HttpGet("id/{id}")]
        public IActionResult GetByIdInvoiceLines(int id)
        {
            var result = _invoiceService.GetByWholeSaleOrderInvoiceLines(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
