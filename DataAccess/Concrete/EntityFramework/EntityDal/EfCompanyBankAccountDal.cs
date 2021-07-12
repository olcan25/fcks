using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.CompanyBankAccount;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfCompanyBankAccountDal : EfEntityRepositoryBase<CompanyBankAccount, InventoryManagementContext>, ICompanyBankAccountDal
    {
        public List<GetDtoCompanyBankAccount> GetAllNameCompanyBankAccounts(Expression<Func<GetDtoCompanyBankAccount, bool>> filter = null)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from companyBankAccount in context.CompanyBankAccounts
                             join bank in context.Banks on companyBankAccount.BankId equals bank.Id
                             join company in context.Companies on companyBankAccount.CompanyId equals company.Id
                             select new GetDtoCompanyBankAccount()
                             {
                                 Id = companyBankAccount.Id,
                                 BankName = bank.Name,
                                 CompanyName = company.Name,
                                 AccountNumber = companyBankAccount.AccountNumber,
                                 Iban = companyBankAccount.Iban,
                                 SwiftCode = companyBankAccount.SwiftCode
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public GetDtoCompanyBankAccount GetNameCompanyBankAccount(Expression<Func<GetDtoCompanyBankAccount, bool>> filter)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from companyBankAccount in context.CompanyBankAccounts
                    join bank in context.Banks on companyBankAccount.BankId equals bank.Id
                    join company in context.Companies on companyBankAccount.CompanyId equals company.Id
                    select new GetDtoCompanyBankAccount()
                    {
                        Id = companyBankAccount.Id,
                        BankName = bank.Name,
                        CompanyName = company.Name,
                        AccountNumber = companyBankAccount.AccountNumber,
                        Iban = companyBankAccount.Iban,
                        SwiftCode = companyBankAccount.SwiftCode
                    };

                return result.FirstOrDefault(filter);
            }
        }
    }
}
