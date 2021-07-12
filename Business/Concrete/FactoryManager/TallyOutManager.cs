using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    public class TallyOutManager : ITallyOutService
    {
        private readonly ITallyOutFactory _tallyOutFactory;
        private readonly IMapper _mapper;
        private readonly ITallyOutFacadeService _tallyOutFacadeService;

        public TallyOutManager(ITallyOutFactory tallyOutFactory, IMapper mapper, ITallyOutFacadeService tallyOutFacadeService)
        {
            _tallyOutFactory = tallyOutFactory;
            _mapper = mapper;
            _tallyOutFacadeService = tallyOutFacadeService;
        }

        [TransactionScopeAspect]
        public IResult Add(Ledger ledger, WholeSaleOrder wholeSaleOrder, List<WholeSaleOrderLine> wholeSaleOrderLines)
        {
            wholeSaleOrderLines.RemoveAll(x => x.ProductId == null || x.ProductId <= 0 || x.VatId <= 0 || x.VatId == null);
            _tallyOutFactory.Create().LedgerService.Add(ledger);
            wholeSaleOrder.LedgerId = ledger.Id;
            _tallyOutFactory.Create().WholeSaleOrderService.Add(wholeSaleOrder);
            foreach (var wholeSaleOrderLine in wholeSaleOrderLines)
            {
                wholeSaleOrderLine.WholeSaleOrderId = wholeSaleOrder.Id;
            }

            //if (wholeSaleOrder.IsPaid)
            //{
            //    var d = _mapper.Map<WholeSaleOrder, Payment>(wholeSaleOrder);
            //    var payment = _mapper.Map(wholeSaleOrderLines, d);
            //    _tallyOutFactory.Create().PaymentService.Add(payment);
            //}

            _tallyOutFactory.Create().WholeSaleOrderLineService.BulkAdd(wholeSaleOrderLines);

            //Product Fiyat Duzenleme
            var products = _mapper.Map<List<Product>>(wholeSaleOrderLines);
            _tallyOutFactory.Create().ProductService.BuyPriceColumnUpdate(products);

            //Financial Proccess
            var ledgerEntries = _tallyOutFacadeService.SaleOfGoods(wholeSaleOrderLines, ledger.Id);
            _tallyOutFactory.Create().LedgerEntryService.AddBulk(ledgerEntries);

            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult Delete(int id)
        {
            var wholeSaleOrder = _tallyOutFactory.Create().WholeSaleOrderService.GetByIdWholeSaleOrder(id).Data;
            var ledger = _tallyOutFactory.Create().LedgerService.GetByIdLedger(wholeSaleOrder.LedgerId).Data;
            var wholeSaleOrderLines = _tallyOutFactory.Create().WholeSaleOrderLineService
                .GetByWholeSaleOrderIdWholeSaleOrderLines(wholeSaleOrder.Id).Data;
            var ledgerEntries = _tallyOutFactory.Create().LedgerEntryService.GetAllByLedgerIdLedgerEntries(wholeSaleOrder.LedgerId).Data;

            //if (wholeSaleOrder.IsPaid)
            //{
            //    var payment = _tallyOutFactory.Create().PaymentService.GetByLedgerIdPayment(ledger.Id).Data;
            //    _tallyOutFactory.Create().PaymentService.Delete(payment);
            //}


            _tallyOutFactory.Create().WholeSaleOrderLineService.BulkDelete(wholeSaleOrderLines);
            _tallyOutFactory.Create().LedgerEntryService.DeleteBulk(ledgerEntries);
            _tallyOutFactory.Create().WholeSaleOrderService.Delete(wholeSaleOrder);
            _tallyOutFactory.Create().LedgerService.Delete(ledger);
            return new SuccessResult(Messages.Deleted);
        }

        [TransactionScopeAspect]
        public IResult Update(Ledger ledger, WholeSaleOrder wholeSaleOrder, List<WholeSaleOrderLine> wholeSaleOrderLines)
        {
            wholeSaleOrderLines.RemoveAll(x => x.ProductId == null || x.ProductId <= 0 || x.VatId <= 0 || x.VatId == null);
            _tallyOutFactory.Create().LedgerService.Update(ledger);
            wholeSaleOrder.LedgerId = ledger.Id;
            _tallyOutFactory.Create().WholeSaleOrderService.Update(wholeSaleOrder);
            foreach (var wholeSaleOrderLine in wholeSaleOrderLines)
            {
                wholeSaleOrderLine.WholeSaleOrderId = wholeSaleOrder.Id;
            }
            //var payment = _tallyOutFactory.Create().PaymentService.GetByLedgerIdPayment(ledger.Id).Data;
            //if (payment != null)
            //{
            //    if (wholeSaleOrder.IsPaid)
            //    {
            //        payment.Amount = wholeSaleOrderLines.Sum(x => x.AmountWithVat);
            //        _tallyOutFactory.Create().PaymentService.Update(payment);
            //    }
            //    else
            //    {
            //        _tallyOutFactory.Create().PaymentService.Delete(payment);
            //    }
            //}
            //else
            //{
            //    if (wholeSaleOrder.IsPaid)
            //    {
            //        var d = _mapper.Map<WholeSaleOrder, Payment>(wholeSaleOrder);
            //        payment = _mapper.Map(wholeSaleOrderLines, d);
            //        _tallyOutFactory.Create().PaymentService.Add(payment);
            //    }
            //}

            _tallyOutFactory.Create().WholeSaleOrderLineService.BulkUpdate(wholeSaleOrderLines);

            //Product Fiyat Duzenleme
            //var products = _mapper.Map<List<Product>>(wholeSaleOrderLines);
            //_tallyOutFactory.Create().ProductService.BuyPriceColumnUpdate(products);

            //Financial Proccess
            var ledgerEntries = _tallyOutFacadeService.SaleOfGoods(wholeSaleOrderLines, ledger.Id);
            _tallyOutFactory.Create().LedgerEntryService.UpdateBulk(ledgerEntries);

            return new SuccessResult(Messages.Modified);
        }
    }
}
