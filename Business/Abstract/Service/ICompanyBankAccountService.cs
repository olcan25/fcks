using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.CompanyBankAccount;

namespace Business.Abstract.Service
{
    public interface ICompanyBankAccountService
    {
        IDataResult<List<GetDtoCompanyBankAccount>> GetAllCompanyBankAccounts();
        IDataResult<GetDtoCompanyBankAccount> GetCompanyBankAccount(short id);
        IDataResult<CompanyBankAccount> GetForDelete(short id);
        IResult AddCompanyBankAccount(CompanyBankAccount companyBankAccount);
        IResult DeleteCompanyBankAccount(CompanyBankAccount companyBankAccount);
        IResult UpdateCompanyBankAccount(CompanyBankAccount companyBankAccount);
    }
}
