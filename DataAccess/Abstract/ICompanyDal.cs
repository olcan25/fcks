using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Company;

namespace DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
    }
}
