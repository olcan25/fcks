using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.LedgerEntryCalculation.Facade.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Concrete.FactoryManager
{
    public class PaymentSystemManager : IPaymentSystemService
    {
        private readonly IPaymentFactory _paymentFactory;
        private readonly IPaymentFacade _paymentFacade;

        public PaymentSystemManager(IPaymentFactory paymentFactory, IPaymentFacade paymentFacade)
        {
            _paymentFactory = paymentFactory;
            _paymentFacade = paymentFacade;
        }
        [TransactionScopeAspect]
        public IResult Add(Ledger ledger, Payment payment)
        {
            _paymentFactory.Create().LedgerService.Add(ledger);
            payment.LedgerId = ledger.Id;
            _paymentFactory.Create().PaymentService.Add(payment);
            var ledgerEntries = _paymentFacade.FinancialPaymentSystem(payment);
            _paymentFactory.Create().LedgerEntryService.AddBulk(ledgerEntries);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(int id)
        {
            var payment = _paymentFactory.Create().PaymentService.GetByIdForDelete(id).Data;
            var ledger = _paymentFactory.Create().LedgerService.GetByIdLedger(payment.LedgerId).Data;

            _paymentFactory.Create().PaymentService.Delete(payment);
            _paymentFactory.Create().LedgerService.Delete(ledger);
            var ledgerEntries = _paymentFactory.Create().LedgerEntryService.GetAllByLedgerIdLedgerEntries(ledger.Id).Data;
            _paymentFactory.Create().LedgerEntryService.DeleteBulk(ledgerEntries);

            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult Update(Ledger ledger, Payment payment)
        {
            _paymentFactory.Create().LedgerService.Update(ledger);
            _paymentFactory.Create().PaymentService.Update(payment);
            var ledgerEntries = _paymentFacade.FinancialPaymentSystem(payment);
            _paymentFactory.Create().LedgerEntryService.UpdateBulk(ledgerEntries);
            return new SuccessResult(Messages.Modified);
        }
    }
}
