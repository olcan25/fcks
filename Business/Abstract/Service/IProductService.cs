using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.DtoLinq;

namespace Business.Abstract.Service
{
    public interface IProductService
    {
        IDataResult<List<DtoProduct>> GetAllDtoProducts();
        IDataResult<DtoProduct> GetByIdDtoProduct(long id);
        IDataResult<List<DtoConditionOfProduct>> GetAllConditionOfProduct();
        IDataResult<List<DtoConditionOfProduct>> GetAllConditionOfProduct(DateTime startDate, DateTime endDate);
        IDataResult<List<DtoCardOfProduct>> GetAllCardOfProducts(long id);
        IDataResult<List<DtoCardOfProduct>> GetAllCardOfProducts(long id, DateTime startDate, DateTime endDate);
        IDataResult<Product> DeleteForId(long id);
        IResult AddProduct(Product product, List<ProductBarcode> productBarcodes);
        IResult DeleteProduct(Product product, List<ProductBarcode> productBarcodes);
        IResult UpdateProduct(Product product, List<ProductBarcode> productBarcodes);
        IResult SellPriceColumnUpdate(List<Product> products);
        IResult BuyPriceColumnUpdate(List<Product> products);
    }
}