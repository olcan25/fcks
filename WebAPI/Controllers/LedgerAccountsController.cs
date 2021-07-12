using AutoMapper;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.ViewModel;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerAccountsController : ControllerBase
    {
        private readonly ILedgerAccountService _ledgerAccountService;
        private readonly ILedgerEntryService _ledgerEntryService;
        private readonly IMapper _mapper;
        public LedgerAccountsController(ILedgerAccountService ledgerAccountService, ILedgerEntryService ledgerEntryService, IMapper mapper)
        {
            _ledgerAccountService = ledgerAccountService;
            _ledgerEntryService = ledgerEntryService;
            _mapper = mapper;
        }

        [HttpGet("detail/{ledgerId}")]
        public IActionResult GetById(long ledgerId)
        {
            var result = _ledgerEntryService.GetAllLedgerAccountsDtoList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("ledgerEntries/{ledgerId}")]
        public IActionResult GetByIdLIst(long ledgerId)
        {
            var result = _ledgerEntryService.GetAllByLedgerIdLedgerEntries(ledgerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ledgerEntryService.GetAllLedgerAccountsDtoList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("betweenDate")]
        public IActionResult GetAllPost(CompareDateEntity compareDate)
        {
            var result = _ledgerEntryService.GetAllLedgerAccountsDtoList(compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(LedgerAccountModel ledgerAccountModel)
        {
            var result = _ledgerAccountService.Add(ledgerAccountModel.Ledger, ledgerAccountModel.LedgerEntries);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{ledgerId}")]
        public IActionResult Delete(long ledgerId)
        {
            var result = _ledgerAccountService.Delete(ledgerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(LedgerAccountModel ledgerAccountModel)
        {
            var result = _ledgerAccountService.Update(ledgerAccountModel.Ledger, ledgerAccountModel.LedgerEntries);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
