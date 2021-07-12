using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.PartnerBankAccount;

namespace DataAccess.Abstract
{
    public interface IPartnerBankAccountDal : IEntityRepository<PartnerBankAccount>
    {
        List<DtoPartnerBankAccount> GetAllDtoPartnerBankAccounts(
            Expression<Func<DtoPartnerBankAccount, bool>> filter = null);

        DtoPartnerBankAccount GetDtoPartnerBankAccount(Expression<Func<DtoPartnerBankAccount, bool>> filter);
    }
}
