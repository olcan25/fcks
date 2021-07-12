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
    public class TallyOutsController : ControllerBase
    {
        private readonly ITallyOutService _tallyOutService;

        public TallyOutsController(ITallyOutService tallyOutService)
        {
            _tallyOutService = tallyOutService;
        }

        [HttpPost]
        public IActionResult Add(WholeSaleOrderModel wholeSaleOrderModel)
        {
            var result = _tallyOutService.Add(wholeSaleOrderModel.Ledger, wholeSaleOrderModel.WholeSaleOrder,
                wholeSaleOrderModel.WholeSaleOrderLines);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _tallyOutService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(WholeSaleOrderModel wholeSaleOrderModel)
        {
            var result = _tallyOutService.Update(wholeSaleOrderModel.Ledger, wholeSaleOrderModel.WholeSaleOrder,
                wholeSaleOrderModel.WholeSaleOrderLines);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
