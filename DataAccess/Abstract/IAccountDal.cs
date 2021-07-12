using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAccountDal : IEntityRepository<Account>
    {
        List<GetAccountDto> GetAllDtoAccounts(Expression<Func<GetAccountDto, bool>> filter = null);
        GetAccountDto GetByIdDtoAccount(Expression<Func<GetAccountDto, bool>> filter);
        List<DtoConditionOfAccount> GetAllDtoConditionOfAccounts(Expression<Func<DtoConditionOfAccount, bool>> filter = null);
        List<DtoConditionOfAccount> GetAllDtoConditionOfAccounts(DateTime startDate, DateTime endDate, Expression<Func<DtoConditionOfAccount, bool>> filter = null);
        List<DtoCardOfAccount> GetAllDtoCardOfAccounts(Expression<Func<DtoCardOfAccount, bool>> filter);
    }
}
