using System.Collections.Generic;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class BankManager : IBankService
    {
        private readonly IBankDal _bankDal;
        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
       
        }
        public IDataResult<List<Bank>> GetAllBanks()
        {
            return new SuccessDataResult<List<Bank>>(_bankDal.GetAll());
        }

        public IDataResult<Bank> GetByIdBank(int id)
        {
            return new SuccessDataResult<Bank>(_bankDal.Get(b => b.Id == id));
        }

        [ValidationAspect(typeof(BankValidator))]
        public IResult AddBank(Bank bank)
        {
            IResult result = BusinessRules.Run(CheckIfBankNameExists(bank.Name), CheckIfBankShortNameExists(bank.ShortName));
            if (result != null) return result;
            _bankDal.Add(bank);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteBank(Bank bank)
        {
            _bankDal.Delete(bank);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(BankValidator))]
        public IResult UpdateBank(Bank bank)
        {
            _bankDal.Update(bank);
            return new SuccessResult(Messages.Modified);
        }
        
        
        
        //Business Rules Codes

        private IResult CheckIfBankNameExists(string name)
        {
            var result = _bankDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Banka Ismi Zaten Var")
                : new SuccessResult();
        }

        private IResult CheckIfBankShortNameExists(string shortName)
        {
            var result = _bankDal.GetIsTrue(x => x.ShortName == shortName);
            return result
                ? (IResult)new ErrorResult("Bu Banka Kisaltma Ismi Zaten Var")
                : new SuccessResult();
        }
    }
}
