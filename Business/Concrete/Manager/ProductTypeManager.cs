using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class ProductTypeManager:IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;

        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }


        public IDataResult<List<ProductType>> GetAllProductTypes()
        {
            return new SuccessDataResult<List<ProductType>>(_productTypeDal.GetAll());
        }

        public IDataResult<ProductType> GetByIdProductType(byte id)
        {
            return new SuccessDataResult<ProductType>(_productTypeDal.Get(x => x.Id == id));
        }
    }
}
