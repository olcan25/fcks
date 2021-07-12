using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.CompanyBankAccount;

namespace Business.Concrete.Manager
{
    public class CompanyBankAccountManager : ICompanyBankAccountService
    {
        private readonly ICompanyBankAccountDal _companyBankAccountDal;

        public CompanyBankAccountManager(ICompanyBankAccountDal companyBankAccountDal)
        {
            _companyBankAccountDal = companyBankAccountDal;
        }

        public IDataResult<List<GetDtoCompanyBankAccount>> GetAllCompanyBankAccounts()
        {
            return new SuccessDataResult<List<GetDtoCompanyBankAccount>>(_companyBankAccountDal.GetAllNameCompanyBankAccounts());
        }

        public IDataResult<GetDtoCompanyBankAccount> GetCompanyBankAccount(short id)
        {
            return new SuccessDataResult<GetDtoCompanyBankAccount>(_companyBankAccountDal.GetNameCompanyBankAccount(x => x.Id == id));
        }

        public IDataResult<CompanyBankAccount> GetForDelete(short id)
        {
            return new SuccessDataResult<CompanyBankAccount>(_companyBankAccountDal.Get(x => x.Id == id));
        }


        [ValidationAspect(typeof(CompanyBankAccountValidator))]
        public IResult AddCompanyBankAccount(CompanyBankAccount companyBankAccount)
        {
            IResult result =
                BusinessRules.Run(CheckIfCompanyBankAccountNumberExists(companyBankAccount.AccountNumber));
            if (result != null) return result;
            _companyBankAccountDal.Add(companyBankAccount);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCompanyBankAccount(CompanyBankAccount companyBankAccount)
        {
            _companyBankAccountDal.Delete(companyBankAccount);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CompanyBankAccountValidator))]
        public IResult UpdateCompanyBankAccount(CompanyBankAccount companyBankAccount)
        {
            _companyBankAccountDal.Update(companyBankAccount);
            return new SuccessResult(Messages.Modified);
        }



        //Business Rules Codes
        
        private IResult CheckIfCompanyBankAccountNumberExists(string accountNumber)
        {
            var result = _companyBankAccountDal.GetIsTrue(x => x.AccountNumber == accountNumber);
            return result
                ? (IResult)new ErrorResult("Bu Hesap Numarasi Zaten Var...")
                : new SuccessResult();
        }
    }
}
