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
using Entity.Dto.Partner;

namespace Business.Concrete.Manager
{
    public class PartnerManager : IPartnerService
    {
        private readonly IPartnerDal _partnerDal;

        public PartnerManager(IPartnerDal partnerDal)
        {
            _partnerDal = partnerDal;
        }


        public IDataResult<List<Partner>> GetAllPartners()
        {
            return new SuccessDataResult<List<Partner>>(_partnerDal.GetAll());
        }

        public IDataResult<Partner> GetByIdPartner(int id)
        {
            return new SuccessDataResult<Partner>(_partnerDal.Get(x => x.Id == id));
        }

        public IDataResult<List<DtoConditionOfPartner>> GetAllConditionOfPartners()
        {
            return new SuccessDataResult<List<DtoConditionOfPartner>>(_partnerDal.GetAllConditionOfPartners());
        }

        public IDataResult<List<DtoConditionOfPartner>> GetAllConditionOfPartners(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoConditionOfPartner>>(_partnerDal.GetAllConditionOfPartners(startDate, endDate));
        }

        public IDataResult<List<DtoCardOfPartner>> GetAllCardOfPartners(int partnerId)
        {
            return new SuccessDataResult<List<DtoCardOfPartner>>(
                _partnerDal.GetAllCardOfPartners(x => x.PartnerId == partnerId));
        }

        public IDataResult<List<DtoCardOfPartner>> GetAllCardOfPartners(int partnerId, DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<DtoCardOfPartner>>(
    _partnerDal.GetAllCardOfPartners(x => x.PartnerId == partnerId && x.RegisterDate >= startDate && x.RegisterDate <= endDate));
        }

        [ValidationAspect(typeof(PartnerValidator))]
        public IResult AddPartner(Partner partner)
        {
            var result = BusinessRules.Run(CheckIfPartnerNameExists(partner.Name),
              CheckIfPartnerUniqueIdentificationNumberExists(
                    partner.UniqueIdentificationNumber),
          CheckIfPartnerVatNumberExists(partner.VatNumber));
            if (result != null) return result;
            _partnerDal.Add(partner);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeletePartner(Partner partner)
        {
            _partnerDal.Delete(partner);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(PartnerValidator))]
        public IResult UpdatePartner(Partner partner)
        {
            _partnerDal.Update(partner);
            return new SuccessResult(Messages.Modified);
        }


        //Business Rules Codes

        private IResult CheckIfPartnerNameExists(string name)
        {
            var result = _partnerDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Partner Ismi Zaten Var")
                : new SuccessResult();
        }

        private IResult CheckIfPartnerVatNumberExists(string vatNumber)
        {
            var result = _partnerDal.GetIsTrue(x => x.VatNumber == vatNumber);
            return result
                ? (IResult)new ErrorResult("Bu KDV Numarasi Zaten Var")
                : new SuccessResult();
        }

        private IResult CheckIfPartnerUniqueIdentificationNumberExists(string uniqueIdentificationNumber)
        {
            var result = _partnerDal.GetIsTrue(x => x.UniqueIdentificationNumber == uniqueIdentificationNumber);
            return result
                ? (IResult)new ErrorResult("Bu UID Numarasi Zaten Var")
                : new SuccessResult();
        }
    }
}
