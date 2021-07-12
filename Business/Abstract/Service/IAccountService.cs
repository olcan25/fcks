using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface IAccountService
    {
        IDataResult<List<GetAccountDto>> GetAllAccounts();
        IDataResult<GetAccountDto> GetByIdAccountDetail(string id);
        IDataResult<Account> GetByIdAccount(string id);
        IDataResult<List<DtoConditionOfAccount>> GetAllConditionOfAccounts();
        IDataResult<List<DtoConditionOfAccount>> GetAllConditionOfAccounts(DateTime startDate, DateTime endDate);
        IDataResult<List<DtoCardOfAccount>> CardOfAccountsList(string accountId);
        IDataResult<List<DtoCardOfAccount>> CardOfAccountsList(string accountId, DateTime startDate, DateTime endDate);
        IResult Add(Account account);
        IResult Delete(Account account);
        IResult Update(Account account);
    }
}
