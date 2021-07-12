using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.CompanyBankAccount;

namespace DataAccess.Abstract
{
    public interface ICompanyBankAccountDal : IEntityRepository<CompanyBankAccount>
    {
        List<GetDtoCompanyBankAccount> GetAllNameCompanyBankAccounts(
            Expression<Func<GetDtoCompanyBankAccount, bool>> filter = null);

        GetDtoCompanyBankAccount GetNameCompanyBankAccount(
            Expression<Func<GetDtoCompanyBankAccount, bool>> filter);
    }
}
