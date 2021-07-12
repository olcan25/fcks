using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class LedgerManager : ILedgerService
    {
        private readonly ILedgerDal _ledgerDal;

        public LedgerManager(ILedgerDal ledgerDal)
        {
            _ledgerDal = ledgerDal;
        }

        public IDataResult<List<Ledger>> GetAllLedgers()
        {
            return new SuccessDataResult<List<Ledger>>(_ledgerDal.GetAll());
        }

        public IDataResult<List<Ledger>> GetAllLedgers(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<Ledger>>(_ledgerDal.GetAll(x => x.RegisterDate >= startDate && x.RegisterDate <= endDate));
        }

        public IDataResult<Ledger> GetByIdLedger(long id)
        {
            return new SuccessDataResult<Ledger>(_ledgerDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(LedgerValidator))]
        public IResult Add(Ledger ledger)
        {
            _ledgerDal.Add(ledger);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Ledger ledger)
        {
            _ledgerDal.Delete(ledger);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(LedgerValidator))]
        public IResult Update(Ledger ledger)
        {
            _ledgerDal.Update(ledger);
            return new SuccessResult(Messages.Modified);
        }

        public IDataResult<Ledger> GetLedgerWithPurchase(long id)
        {
            return new SuccessDataResult<Ledger>(_ledgerDal.GetLedgerWithPurchase(x => x.Id == id));
        }

        public IDataResult<Ledger> GetLedgerWithWholeSale(long id)
        {
            return new SuccessDataResult<Ledger>(_ledgerDal.GetLedgerWithWholeSale(x => x.Id == id));
        }


    }
}
