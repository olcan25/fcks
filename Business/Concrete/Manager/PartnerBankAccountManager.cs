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
using Entity.Dto.PartnerBankAccount;

namespace Business.Concrete.Manager
{
    public class PartnerBankAccountManager : IPartnerBankAccountService
    {
        private readonly IPartnerBankAccountDal _partnerBankAccountDal;

        public PartnerBankAccountManager(IPartnerBankAccountDal partnerBankAccountDal)
        {
            _partnerBankAccountDal = partnerBankAccountDal;
        }
        public IDataResult<List<DtoPartnerBankAccount>> GetAllDtoPartnerBankAccounts()
        {
            return new SuccessDataResult<List<DtoPartnerBankAccount>>(_partnerBankAccountDal
                .GetAllDtoPartnerBankAccounts());
        }

        public IDataResult<DtoPartnerBankAccount> GetByIdDtoPartnerBankAccount(int id)
        {
            return new SuccessDataResult<DtoPartnerBankAccount>(
                _partnerBankAccountDal.GetDtoPartnerBankAccount(x => x.Id == id));
        }

        public IDataResult<PartnerBankAccount> GetForDelete(int id)
        {
            return new SuccessDataResult<PartnerBankAccount>(_partnerBankAccountDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(PartnerBankAccountValidator))]
        public IResult AddPartnerBankAccount(PartnerBankAccount partnerBankAccount)
        {
            var result =
                BusinessRules.Run(
                  CheckIfPartnerBankAccountNumberExists(partnerBankAccount
                        .AccountNumber));
            if (result != null) return result;
            _partnerBankAccountDal.Add(partnerBankAccount);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeletePartnerBankAccount(PartnerBankAccount partnerBankAccount)
        {
            _partnerBankAccountDal.Delete(partnerBankAccount);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(PartnerBankAccountValidator))]
        public IResult UpdatePartnerBankAccount(PartnerBankAccount partnerBankAccount)
        {
            _partnerBankAccountDal.Update(partnerBankAccount);
            return new SuccessResult(Messages.Modified);
        }


        //Business Rules Codes

        private IResult CheckIfPartnerBankAccountNumberExists(string accountNumber)
        {
            var result = _partnerBankAccountDal.GetIsTrue(x => x.AccountNumber == accountNumber);
            return result
                ? (IResult)new ErrorResult("Bu Hesap Numarasi Zaten Var...")
                : new SuccessResult();
        }
    }
}
