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
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;

        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _unitOfMeasureService.GetAllUnitOfMeasures();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(short id)
        {
            var result = _unitOfMeasureService.GetByIdUnitOfMeasure(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(UnitOfMeasure unitOfMeasure)
        {
            var result = _unitOfMeasureService.AddUnitOfMeasure(unitOfMeasure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var unitOfMeasure = _unitOfMeasureService.GetByIdUnitOfMeasure(id).Data;
            var result = _unitOfMeasureService.DeleteUnitOfMeasure(unitOfMeasure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(UnitOfMeasure unitOfMeasure)
        {
            var result = _unitOfMeasureService.UpdateUnitOfMeasure(unitOfMeasure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
