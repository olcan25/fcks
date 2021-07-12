using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using EFCore.BulkExtensions;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.DtoLinq;

namespace Business.Concrete.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductBarcodeService _productBarcodeService;

        public ProductManager(IProductDal productDal, IProductBarcodeService productBarcodeService)
        {
            _productDal = productDal;
            _productBarcodeService = productBarcodeService;
        }


        public IDataResult<List<DtoProduct>> GetAllDtoProducts()
        {
            return new SuccessDataResult<List<DtoProduct>>(_productDal.GetAllDtoProducts());
        }

        public IDataResult<DtoProduct> GetByIdDtoProduct(long id)
        {
            return new SuccessDataResult<DtoProduct>(_productDal.GetDtoProduct(x => x.Id == id));
        }

        public IDataResult<List<DtoConditionOfProduct>> GetAllConditionOfProduct()
        {
            return new SuccessDataResult<List<DtoConditionOfProduct>>(_productDal.GetAllConditionOfProducts());
        }

        public IDataResult<List<DtoConditionOfProduct>> GetAllConditionOfProduct(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoConditionOfProduct>>(_productDal.GetAllConditionOfProducts(startDate, endDate));
        }

        public IDataResult<List<DtoCardOfProduct>> GetAllCardOfProducts(long id)
        {
            return new SuccessDataResult<List<DtoCardOfProduct>>(
                _productDal.GetAAllCardOdProducts(x => x.ProductId == id));
        }

        public IDataResult<List<DtoCardOfProduct>> GetAllCardOfProducts(long id, DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoCardOfProduct>>(_productDal.GetAAllCardOdProducts(x => x.ProductId == id && x.RegisterDate >= startDate && x.RegisterDate <= endDate));
        }

        public IDataResult<Product> DeleteForId(long id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product, List<ProductBarcode> productBarcodes)
        {
            _productDal.Add(product);
            foreach (var productBarcode in productBarcodes)
            {
                productBarcode.ProductId = product.Id;
            }

            _productBarcodeService.AddBulk(productBarcodes);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteProduct(Product product, List<ProductBarcode> productBarcodes)
        {
            _productBarcodeService.DeleteBulk(productBarcodes);
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult UpdateProduct(Product product, List<ProductBarcode> productBarcodes)
        {
            _productDal.Update(product);
            foreach (var productBarcode in productBarcodes)
            {
                productBarcode.ProductId = product.Id;
            }

            _productBarcodeService.UpdateBulk(productBarcodes);
            return new SuccessResult(Messages.Added);
        }

        public IResult SellPriceColumnUpdate(List<Product> products)
        {
            List<string> propertiesToIncludeOnUpdate = new List<string>
            {
                nameof(Product.DefaultSellingPrice)
            };
            _productDal.BulkUpdateModifyProperties(products, propertiesToIncludeOnUpdate: propertiesToIncludeOnUpdate);
            return new SuccessResult(Messages.Modified);
        }

        public IResult BuyPriceColumnUpdate(List<Product> products)
        {
            List<string> propertiesToIncludeOnUpdate = new List<string>
            {
                nameof(Product.DefaultBuyingPrice)
            };
            _productDal.BulkUpdateModifyProperties(products, propertiesToIncludeOnUpdate: propertiesToIncludeOnUpdate);
            return new SuccessResult(Messages.Modified);
        }


        //Business Rules Codes

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Urun Ismi Zaten Var...")
                : new SuccessResult();
        }
    }
}
