using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyBankAccountsController : ControllerBase
    {
        private readonly ICompanyBankAccountService _companyBankAccountService;

        public CompanyBankAccountsController(ICompanyBankAccountService companyBankAccountService)
        {
            _companyBankAccountService = companyBankAccountService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyBankAccountService.GetAllCompanyBankAccounts();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetAll(short id)
        {
            var result = _companyBankAccountService.GetCompanyBankAccount(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(CompanyBankAccount companyBankAccount)
        {
            var result = _companyBankAccountService.AddCompanyBankAccount(companyBankAccount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Add(short id)
        {
            var companyBankAccount = _companyBankAccountService.GetForDelete(id).Data;
            var result = _companyBankAccountService.DeleteCompanyBankAccount(companyBankAccount);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);

        }

        [HttpPut]
        public IActionResult Update(CompanyBankAccount companyBankAccount)
        {
            var result = _companyBankAccountService.UpdateCompanyBankAccount(companyBankAccount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
