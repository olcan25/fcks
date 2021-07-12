using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstract.FactoryService;
using Business.IoCHell.Business.Factory.Abstract;
using Business.LedgerEntryCalculation.Facade.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Concrete.FactoryManager
{
    public class TallyInManager : ITallyInService
    {
        private readonly ITallyInFactory _tallyInFactory;
        private readonly IMapper _mapper;
        private readonly ITallyInFacade _tallyInFacade;

        public TallyInManager(ITallyInFactory tallyInFactory, IMapper mapper, ITallyInFacade tallyInFacade)
        {
            _tallyInFactory = tallyInFactory;
            _mapper = mapper;
            _tallyInFacade = tallyInFacade;
        }

        [TransactionScopeAspect]
        public IResult Add(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines)
        {
            purchaseOrderLines.RemoveAll(x => x.ProductId == null || x.ProductId <= 0 || x.VatId <= 0 || x.VatId == null);
            _tallyInFactory.Create().LedgerService.Add(ledger);

            purchaseOrder.LedgerId = ledger.Id;
            _tallyInFactory.Create().PurchaseOrderService.Add(purchaseOrder);
            foreach (var purchaseOrderLine in purchaseOrderLines)
            {
                purchaseOrderLine.PurchaseOrderId = purchaseOrder.Id;
            }

            //if (purchaseOrder.IsPaid)
            //{
            //    var d = _mapper.Map<PurchaseOrder, Payment>(purchaseOrder);
            //    var payment = _mapper.Map(purchaseOrderLines, d);
            //    _tallyInFactory.Create().PaymentService.Add(payment);
            //}



            _tallyInFactory.Create().PurchaseOrderLineService.BulkAdd(purchaseOrderLines);

            //Urun Fiyat Degistirme
            var products = _mapper.Map<List<Product>>(purchaseOrderLines);
            _tallyInFactory.Create().ProductService.BuyPriceColumnUpdate(products);


            //Financial Proccess
            var ledgerEntries = _tallyInFacade.RegisterGoods(purchaseOrderLines, ledger.Id);
            _tallyInFactory.Create().LedgerEntryService.AddBulk(ledgerEntries);

            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(int id)
        {
            var purchaseOrder = _tallyInFactory.Create().PurchaseOrderService.GetByIdPurchaseOrder(id).Data;
            var ledger = _tallyInFactory.Create().LedgerService.GetByIdLedger(purchaseOrder.LedgerId).Data;
            var purchaseOrderLines = _tallyInFactory.Create().PurchaseOrderLineService
                .GetByPurchaseOrderIdPurchaseOrderLines(purchaseOrder.Id).Data;
            var ledgerEntries = _tallyInFactory.Create().LedgerEntryService.GetAllByLedgerIdLedgerEntries(purchaseOrder.LedgerId).Data;

            //if (purchaseOrder.IsPaid)
            //{
            //    var payment = _tallyInFactory.Create().PaymentService.GetByLedgerIdPayment(ledger.Id).Data;
            //    _tallyInFactory.Create().PaymentService.Delete(payment);
            //}

            _tallyInFactory.Create().PurchaseOrderLineService.BulkDelete(purchaseOrderLines);
            //Financial Proccess
            _tallyInFactory.Create().LedgerEntryService.DeleteBulk(ledgerEntries);
            _tallyInFactory.Create().PurchaseOrderService.Delete(purchaseOrder);
            _tallyInFactory.Create().LedgerService.Delete(ledger);


            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult Update(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines)
        {
            purchaseOrderLines.RemoveAll(x => x.ProductId == null || x.ProductId <= 0 || x.VatId <= 0 || x.VatId == null);
            _tallyInFactory.Create().LedgerService.Update(ledger);
            purchaseOrder.LedgerId = ledger.Id;
            var payment = _tallyInFactory.Create().PaymentService.GetByLedgerIdPayment(ledger.Id).Data;
            //if (payment != null)
            //{
            //    if (purchaseOrder.IsPaid)
            //    {
            //        payment.Amount = purchaseOrderLines.Sum(x => x.AmountWithVat);
            //        _tallyInFactory.Create().PaymentService.Update(payment);
            //    }
            //    else
            //    {
            //        _tallyInFactory.Create().PaymentService.Delete(payment);
            //    }
            //}
            //else
            //{
            //    if (purchaseOrder.IsPaid)
            //    {
            //        var d = _mapper.Map<PurchaseOrder, Payment>(purchaseOrder);
            //        payment = _mapper.Map(purchaseOrderLines, d);
            //        _tallyInFactory.Create().PaymentService.Add(payment);
            //    }
            //}
            _tallyInFactory.Create().PurchaseOrderService.Update(purchaseOrder);
            foreach (var purchaseOrderLine in purchaseOrderLines)
            {
                purchaseOrderLine.PurchaseOrderId = purchaseOrder.Id;
            }
            _tallyInFactory.Create().PurchaseOrderLineService.BulkUpdate(purchaseOrderLines);

            //Urun Fiyat Degistirme
            //var products = _mapper.Map<List<Product>>(purchaseOrderLines);
            //_tallyInFactory.Create().ProductService.BuyPriceColumnUpdate(products);

            //Financial Proccess
            List<LedgerEntry> ledgerEntries = _tallyInFacade.RegisterGoods(purchaseOrderLines, ledger.Id);
            _tallyInFactory.Create().LedgerEntryService.UpdateBulk(ledgerEntries);

            //
            return new SuccessResult(Messages.Modified);
        }
    }
}