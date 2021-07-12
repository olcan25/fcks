using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Service;
using Entity.Concrete;
using Entity.Dto.Ledger;
using Entity.Dto.PurchaseOrder;
using Entity.Dto.PurchaseOrderLine;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _purchaseOrderService.GetAllPurchaseOrderDtos();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _purchaseOrderService.GetByIdPurchaseOrderDto(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("ledgerId/{ledgerId}")]
        public IActionResult GetByLedgerId(long ledgerId)
        {
            var result = _purchaseOrderService.GetByLedgerIdPurchaseOrder(ledgerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetByIdDetail(int id)
        {
            var result = _purchaseOrderService.GetByIdPurchaseOrder(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
