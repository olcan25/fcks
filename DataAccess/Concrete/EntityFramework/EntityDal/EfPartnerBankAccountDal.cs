using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dto.PartnerBankAccount;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPartnerBankAccountDal : EfEntityRepositoryBase<PartnerBankAccount, InventoryManagementContext>,
        IPartnerBankAccountDal
    {
        public List<DtoPartnerBankAccount> GetAllDtoPartnerBankAccounts(Expression<Func<DtoPartnerBankAccount, bool>> filter = null)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from partnerBankAccount in context.PartnerBankAccounts
                             join bank in context.Banks on partnerBankAccount.BankId equals bank.Id
                             join partner in context.Partners on partnerBankAccount.PartnerId equals partner.Id
                             select new DtoPartnerBankAccount()
                             {
                                 Id = partnerBankAccount.Id,
                                 BankName = bank.Name,
                                 PartnerName = partner.Name,
                                 AccountNumber = partnerBankAccount.AccountNumber,
                                 Iban = partnerBankAccount.Iban,
                                 SwiftCode = partnerBankAccount.SwiftCode
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public DtoPartnerBankAccount GetDtoPartnerBankAccount(Expression<Func<DtoPartnerBankAccount, bool>> filter)
        {
            using (var context = new InventoryManagementContext())
            {
                var result = from partnerBankAccount in context.PartnerBankAccounts
                    join bank in context.Banks on partnerBankAccount.BankId equals bank.Id
                    join partner in context.Partners on partnerBankAccount.PartnerId equals partner.Id
                    select new DtoPartnerBankAccount()
                    {
                        Id = partnerBankAccount.Id,
                        BankName = bank.Name,
                        PartnerName = partner.Name,
                        AccountNumber = partnerBankAccount.AccountNumber,
                        Iban = partnerBankAccount.Iban,
                        SwiftCode = partnerBankAccount.SwiftCode
                    };

                return result.FirstOrDefault(filter);
            }
        }
    }
}
