using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.IoCHell.Business.Factory.Abstract;
using Business.ViewModel;
using AutoMapper;
using Entity.DtoLinq;
using Entity.Dto.Product;
using Core.Utilities.Result;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportFactory _reportFactory;

        public ReportsController(IReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }
        #region ProductReports
        [HttpGet("ConditionOfProducts")]
        public IActionResult GetAllConditionOfProduct()
        {
            var result = _reportFactory.Create().ProductService.GetAllConditionOfProduct();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("ConditionOfProducts")]
        public IActionResult Deneme(CompareDateEntity compareDate)
        {
            var result = _reportFactory.Create().ProductService.GetAllConditionOfProduct(compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("CardOfProducts/{id}")]
        public IActionResult GetAllCardOfProducts(int id)
        {
            var result = _reportFactory.Create().ProductService.GetAllCardOfProducts(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("CardOfProducts/{id}")]
        public IActionResult GetAllCardOfProducts(int id, CompareDateEntity compareDateEntity)
        {
            var result = _reportFactory.Create().ProductService.GetAllCardOfProducts(id, compareDateEntity.StartDate, compareDateEntity.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        #endregion

        #region PartnerReports
        [HttpGet("ConditionOfPartners")]
        public IActionResult GetAllConditionOfPartners()
        {
            var result = _reportFactory.Create().PartnerService.GetAllConditionOfPartners();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("ConditionOfPartners")]
        public IActionResult GetAllConditionOfPartners(CompareDateEntity compareDate)
        {
            var result = _reportFactory.Create().PartnerService.GetAllConditionOfPartners(compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("CardOfPartners/{partnerId}")]
        public IActionResult GetByPartnerId(int partnerId)
        {
            var result = _reportFactory.Create().PartnerService.GetAllCardOfPartners(partnerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("CardOfPartners/{partnerId}")]
        public IActionResult GetByPartnerId(int partnerId, CompareDateEntity compareDate)
        {
            var result = _reportFactory.Create().PartnerService.GetAllCardOfPartners(partnerId, compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        #endregion

        #region AccountReports
        [HttpGet("ConditionOfAccounts")]
        public IActionResult GetAllConditionOfAccounts()
        {
            var result = _reportFactory.Create().AccountService.GetAllConditionOfAccounts();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("ConditionOfAccounts")]
        public IActionResult GetAllConditionOfAccounts(CompareDateEntity compareDate)
        {
            var result = _reportFactory.Create().AccountService.GetAllConditionOfAccounts(compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("CardOfAccounts/{accountId}")]
        public IActionResult GetListCardOfAccounts(string accountId)
        {
            var result = _reportFactory.Create().AccountService.CardOfAccountsList(accountId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("CardOfAccounts/{accountId}")]
        public IActionResult GetListCardOfAccounts(string accountId, CompareDateEntity compareDate)
        {
            var result = _reportFactory.Create().AccountService.CardOfAccountsList(accountId, compareDate.StartDate, compareDate.EndDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
    #endregion
}
