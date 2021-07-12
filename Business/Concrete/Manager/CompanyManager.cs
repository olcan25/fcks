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
using Entity.Dto.Company;

namespace Business.Concrete.Manager
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IDataResult<List<Company>> GetAllCompanies()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll());
        }

        public IDataResult<Company> GetByIdCompany(short id)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(x => x.Id == id));
        }

        public IDataResult<Company> GetFirstCompany()
        {
            return new SuccessDataResult<Company>(_companyDal.GetAll().FirstOrDefault());
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult AddCompany(Company company)
        {
            IResult result = BusinessRules.Run(CompanyNameExists(company.Name),
                CompanyUniqueIdentificationNumberExists(company.UniqueIdentificationNumber),
               CompanyVatNumberExists(company.VatNumber));
            if (result != null) return result;
            
            _companyDal.Add(company);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCompany(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult UpdateCompany(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(Messages.Modified);
        }



        //Business Rules Codes

        private IResult CompanyNameExists(string name)
        {
            var result = _companyDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Sirket Ismi Zaten Var")
                : new SuccessResult();
        }

        private IResult CompanyVatNumberExists(string vatNumber)
        {
            var result = _companyDal.GetIsTrue(x => x.VatNumber == vatNumber);
            return result
                ? (IResult)new ErrorResult("Bu Sirket KDV Numarasi Zaten Var")
                : new SuccessResult();
        }

        private IResult CompanyUniqueIdentificationNumberExists(string uniqueIdentificationNumber)
        {
            var result = _companyDal.GetIsTrue(x => x.UniqueIdentificationNumber == uniqueIdentificationNumber);
            return result
                ? (IResult)new ErrorResult("Bu Sirket ID Numarasi Zaten Var")
                : new SuccessResult();
        }
    }
}
