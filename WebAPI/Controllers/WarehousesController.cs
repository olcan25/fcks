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
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehousesService _warehousesService;

        public WarehousesController(IWarehousesService warehousesService)
        {
            _warehousesService = warehousesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _warehousesService.GetAllDtoWarehouses();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(byte id)
        {
            var result = _warehousesService.GetByIdDtoWarehouse(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("companyId/{companyId}")]
        public IActionResult GetWarehousesByCompanyId(short companyId)
        {
            var result = _warehousesService.GetComapnyIdWarehouses(companyId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Warehouse warehouse)
        {
            var result = _warehousesService.AddWarehouse(warehouse);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(byte id)
        {
            var warehouse = _warehousesService.DeleteForId(id).Data;
            var result = _warehousesService.DeleteWarehouse(warehouse);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(Warehouse warehouse)
        {
            var result = _warehousesService.UpdateWarehouse(warehouse);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
