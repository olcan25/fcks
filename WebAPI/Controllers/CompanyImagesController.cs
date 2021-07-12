using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Service;
using Core.Utilities.ImageUploadClouds;
using Entity.Concrete;
using Entity.Dto.CompanyImage;
using log4net.Core;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyImagesController : ControllerBase
    {
        private readonly ICloudinaryHelper _cloudinaryHelper;
        private readonly IMapper _mapper;

        public CompanyImagesController(ICloudinaryHelper cloudinaryHelper, IMapper mapper)
        {
            _cloudinaryHelper = cloudinaryHelper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var result = _companyImageService.GetAllCompanyImages();
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            //return BadRequest(result.Message);
            return BadRequest("Sonra Duzeltirim");
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetById(int id)
        {
            //var result = _companyImageService.GetByIdCompanyImage(id);
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            //return BadRequest(result.Message);
            return BadRequest("Sonra Duzeltirim");
        }


        
        [HttpPost("{companyId}")]//Hem Update Hem de Add Islemi icin
        public IActionResult Add(short companyId, [FromForm]IFormFile file)
        {
            //var companyImage = new CompanyImage();
            //var uploadResult = _cloudinaryHelper.CreateAccount(file);
            //companyImage.Url = uploadResult[0];
            //companyImage.PublicId = uploadResult[1];

            //companyImage.CompanyId = companyId;
            //var result = _companyImageService.Add(companyImage);
            //if (result.Success)
            //{
            //    return Ok(result.Message);
            //}

            //return BadRequest(result.Message);
            return BadRequest("Sonra Duzeltirim");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var companyImage = _companyImageService.GetByIdCompanyImage(id).Data;
            //var deleteImageResult = _cloudinaryHelper.DeleteAccount(companyImage.PublicId);
            //if (deleteImageResult == "ok")
            //{
            //    var result = _companyImageService.Delete(companyImage);
            //    if (result.Success)
            //    {
            //        return Ok(result.Message);
            //    }
            //}
            //return BadRequest("Image Delete Process Error");
            return BadRequest("Sonra Duzeltirim");

        }
    }
}
