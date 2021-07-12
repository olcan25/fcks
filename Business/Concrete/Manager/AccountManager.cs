using Business.Abstract.Service;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IResult Add(Account account)
        {
            IResult result = BusinessRules.Run(CheckIfAccountIdExists(account.Id), CheckIfAccountNameExists(account.Name));
            if (result != null) return result;
            _accountDal.Add(account);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Account account)
        {
            _accountDal.Delete(account);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<GetAccountDto>> GetAllAccounts()
        {
            return new SuccessDataResult<List<GetAccountDto>>(_accountDal.GetAllDtoAccounts());
        }

        public IDataResult<GetAccountDto> GetByIdAccountDetail(string id)
        {
            return new SuccessDataResult<GetAccountDto>(_accountDal.GetByIdDtoAccount(x => x.Id == id));
        }

        public IDataResult<Account> GetByIdAccount(string id)
        {
            return new SuccessDataResult<Account>(_accountDal.Get(x => x.Id == id));
        }

        public IDataResult<List<DtoConditionOfAccount>> GetAllConditionOfAccounts()
        {
            return new SuccessDataResult<List<DtoConditionOfAccount>>(_accountDal.GetAllDtoConditionOfAccounts());
        }
        public IDataResult<List<DtoConditionOfAccount>> GetAllConditionOfAccounts(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoConditionOfAccount>>(_accountDal.GetAllDtoConditionOfAccounts(startDate, endDate));
        }

        public IDataResult<List<DtoCardOfAccount>> CardOfAccountsList(string accountId)
        {
            return new SuccessDataResult<List<DtoCardOfAccount>>(_accountDal.GetAllDtoCardOfAccounts(x => x.AccountId == accountId));
        }

        public IDataResult<List<DtoCardOfAccount>> CardOfAccountsList(string accountId, DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoCardOfAccount>>(_accountDal.GetAllDtoCardOfAccounts(x => x.AccountId == accountId && x.RegisterDate >= startDate && x.RegisterDate <= endDate));
        }

        public IResult Update(Account account)
        {
            IResult result = BusinessRules.Run(CheckIfAccountIdExists(account.Id), CheckIfAccountNameExists(account.Name));
            if (result != null) return result;
            _accountDal.Update(account);
            return new SuccessResult(Messages.Modified);
        }

        //Business Rules
        private IResult CheckIfAccountNameExists(string name)
        {
            var result = _accountDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Hesap Ismi Zaten Var")
                : new SuccessResult();
        }

        private IResult CheckIfAccountIdExists(string id)
        {
            var result = _accountDal.GetIsTrue(x => x.Id == id);
            return result
                ? (IResult)new ErrorResult("Bu Hesap Numarasi Zaten Var")
                : new SuccessResult();
        }


    }
}
