using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.ViewModel;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentSystemService _paymentSystemService;

        public PaymentsController(IPaymentService paymentService, IPaymentSystemService paymentSystemService)
        {
            _paymentService = paymentService;
            _paymentSystemService = paymentSystemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAllListDtoPayments();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetByIdDetail(int id)
        {
            var result = _paymentService.GetByIdDtoPayment(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _paymentService.GetByIdForDelete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("ledgerId/{ledgerId}")]
        public IActionResult GetByLedgerId(long ledgerId)
        {
            var result = _paymentService.GetByLedgerIdPayment(ledgerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(PaymentModel paymentModel)
        {
            var result = _paymentSystemService.Add(paymentModel.Ledger, paymentModel.Payment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _paymentSystemService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(PaymentModel paymentModel)
        {
            var result = _paymentSystemService.Update(paymentModel.Ledger, paymentModel.Payment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
