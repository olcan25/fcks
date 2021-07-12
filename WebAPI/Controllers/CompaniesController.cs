using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Service;
using Business.ViewModel;
using Core.Utilities.ImageUploadClouds;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICloudinaryHelper _cloudinaryHelper;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, ICloudinaryHelper cloudinaryHelper, IMapper mapper)
        {
            _companyService = companyService;
            _cloudinaryHelper = cloudinaryHelper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _companyService.GetAllCompanies();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("first")]
        public IActionResult GetFirstCompany()
        {
            var result = _companyService.GetFirstCompany();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(short id)
        {
            var result = _companyService.GetByIdCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add([FromForm] CompanyModel companyModel)
        {
            var company = _mapper.Map<Company>(companyModel);
            var uploadResult = _cloudinaryHelper.CreateAccount(companyModel.File);
            company.ImageUrl = uploadResult[0];
            company.PublicId = uploadResult[1];
            var result = _companyService.AddCompany(company);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var company = _companyService.GetByIdCompany(id).Data;
            var result = _companyService.DeleteCompany(company);
            if (result.Success)
            {
                var deleteImageResult = _cloudinaryHelper.DeleteAccount(company.PublicId);
                if (deleteImageResult == "ok")
                {
                    return Ok(result);
                }

            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(Company company)
        {
            var result = _companyService.UpdateCompany(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
