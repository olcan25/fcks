using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IProductBarcodeService
    {
        IDataResult<List<ProductBarcode>> GetAllProductBarcodes();
        IDataResult<List<ProductBarcode>> GetByProductIdProductBarcodes(long productId);
        IDataResult<ProductBarcode> GetByIdProductBarcode(int id);
        IResult AddBulk(List<ProductBarcode> productBarcodes);
        IResult DeleteBulk(List<ProductBarcode> productBarcodes);
        IResult UpdateBulk(List<ProductBarcode> productBarcodes);
    }
}
