using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class ProductBarcodeManager : IProductBarcodeService
    {
        private readonly IProductBarcodeDal _productBarcodeDal;

        public ProductBarcodeManager(IProductBarcodeDal productBarcodeDal)
        {
            _productBarcodeDal = productBarcodeDal;
        }
        public IDataResult<List<ProductBarcode>> GetAllProductBarcodes()
        {
            return new SuccessDataResult<List<ProductBarcode>>(_productBarcodeDal.GetAll());
        }

        public IDataResult<List<ProductBarcode>> GetByProductIdProductBarcodes(long productId)
        {
            return new SuccessDataResult<List<ProductBarcode>>(
                _productBarcodeDal.GetAll(x => x.ProductId == productId));
        }

        public IDataResult<ProductBarcode> GetByIdProductBarcode(int id)
        {
            return new SuccessDataResult<ProductBarcode>(_productBarcodeDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(ProductBarcodeValidator), Priority = 1)]
        public IResult AddBulk(List<ProductBarcode> productBarcodes)
        {
            IResult result = BusinessRules.Run(CheckIfProductBarcodeExists(productBarcodes));
            if (result != null) return result;
            _productBarcodeDal.BulkInsert(productBarcodes);
            return new SuccessResult(Messages.Added);
        }


        public IResult DeleteBulk(List<ProductBarcode> productBarcodes)
        {
            _productBarcodeDal.BulkDelete(productBarcodes);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(ProductBarcodeValidator), Priority = 1)]
        public IResult UpdateBulk(List<ProductBarcode> productBarcodes)
        {
            _productBarcodeDal.BulkSynchronize(productBarcodes);
            return new SuccessResult(Messages.Modified);
        }

        private IResult CheckIfProductBarcodeExists(List<ProductBarcode> productBarcodes)
        {
            var result = true;
            foreach (var productBarcode in productBarcodes)
            {
                result =_productBarcodeDal.GetIsTrue(x => x.Barcode==productBarcode.Barcode);
            }

            return result
                ? (IResult)new ErrorResult("Bu Barkod Zaten Var...")
                : new SuccessResult();
        }
    }
}
