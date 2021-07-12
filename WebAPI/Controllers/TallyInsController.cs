using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallyInsController : ControllerBase
    {
        private readonly ITallyInService _tallyInService;

        public TallyInsController(ITallyInService tallyInService)
        {
            _tallyInService = tallyInService;
        }

        [HttpPost]
        public IActionResult Add(PurchaseOrderModel purchaseOrderModel)
        {
            //purchaseOrderModel.PurchaseOrder.TransporterId==0?null:purchaseOrderModel.PurchaseOrder.TransporterId;
            var result = _tallyInService.Add(purchaseOrderModel.Ledger, purchaseOrderModel.PurchaseOrder,
                purchaseOrderModel.PurchaseOrderLines);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _tallyInService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPut]
        public IActionResult Update(PurchaseOrderModel purchaseOrderModel)
        {
            var result = _tallyInService.Update(purchaseOrderModel.Ledger, purchaseOrderModel.PurchaseOrder,
                purchaseOrderModel.PurchaseOrderLines);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
