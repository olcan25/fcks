using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Product;
using Entity.DtoLinq;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<DtoProduct> GetAllDtoProducts(Expression<Func<DtoProduct, bool>> filter = null);
        DtoProduct GetDtoProduct(Expression<Func<DtoProduct, bool>> filter);
        List<DtoCardOfProduct> GetAAllCardOdProducts(Expression<Func<DtoCardOfProduct, bool>> filter = null);
        List<DtoConditionOfProduct> GetAllConditionOfProducts(Expression<Func<DtoConditionOfProduct, bool>> filter = null);
        List<DtoConditionOfProduct> GetAllConditionOfProducts(DateTime startDate, DateTime endDate, Expression<Func<DtoConditionOfProduct, bool>> filter = null);
    }
}
