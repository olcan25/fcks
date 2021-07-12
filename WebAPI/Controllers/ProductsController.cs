using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.ViewModel;
using Core.Utilities.FileUpload;
using Entity.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IProductBarcodeService _productBarcodeService;


        public ProductsController(IProductService productService,IProductBarcodeService productBarcodeService)
        {
            _productService = productService;
            _productBarcodeService = productBarcodeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAllDtoProducts();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetByIdDetail(int id)
        {
            var result = _productService.GetByIdDtoProduct(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.DeleteForId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("barcodes/{productId}")]
        public IActionResult GetByProductIdBarcodes(int productId)
        {
            var result = _productBarcodeService.GetByProductIdProductBarcodes(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add(ProductModel productModel)
        {
            var result = _productService.AddProduct(productModel.Product, productModel.ProductBarcodes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var product = _productService.DeleteForId(id).Data;
            var productBarcodes = _productBarcodeService.GetByProductIdProductBarcodes(product.Id).Data;
            var result = _productService.DeleteProduct(product, productBarcodes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(ProductModel productModel)
        {
            var result = _productService.UpdateProduct(productModel.Product, productModel.ProductBarcodes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
