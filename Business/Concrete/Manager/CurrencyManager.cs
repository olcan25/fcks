using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }

        [ValidationAspect(typeof(CurrencyValidator))]
        public IResult Add(Currency currency)
        {
            _currencyDal.Add(currency);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Currency currency)
        {
            _currencyDal.Delete(currency);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Currency>> GetAllCurrencies()
        {
            return new SuccessDataResult<List<Currency>>(_currencyDal.GetAll());
        }

        public IDataResult<Currency> GetByIdCurrency(short id)
        {
            return new SuccessDataResult<Currency>(_currencyDal.Get(x => x.Id == id));
        }
        [ValidationAspect(typeof(CurrencyValidator))]
        public IResult Update(Currency currency)
        {
            _currencyDal.Update(currency);
            return new SuccessResult(Messages.Modified);
        }
    }
}
