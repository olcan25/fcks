using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Company;

namespace Business.Abstract.Service
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAllCompanies();
        IDataResult<Company> GetByIdCompany(short id);
        IDataResult<Company> GetFirstCompany();
        IResult AddCompany(Company company);
        IResult DeleteCompany(Company company);
        IResult UpdateCompany(Company company);
    }
}
