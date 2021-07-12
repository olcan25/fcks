using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.PurchaseOrder;

namespace Business.Concrete.Manager
{
    public class PurchaseOrderManager : IPurchaseOrderService
    {
        private readonly IPurchaseOrderDal _purchaseOrderDal;

        public PurchaseOrderManager(IPurchaseOrderDal purchaseOrderDal)
        {
            _purchaseOrderDal = purchaseOrderDal;
        }
        public IDataResult<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            return new SuccessDataResult<List<PurchaseOrder>>(_purchaseOrderDal.GetAll());
        }

        public IDataResult<PurchaseOrder> GetByIdPurchaseOrder(int id)
        {
            return new SuccessDataResult<PurchaseOrder>(_purchaseOrderDal.Get(x => x.Id == id));
        }

        public IDataResult<PurchaseOrder> GetByLedgerIdPurchaseOrder(long ledgerId)
        {
            return new SuccessDataResult<PurchaseOrder>(_purchaseOrderDal.Get(x => x.LedgerId == ledgerId));
        }

        public IDataResult<List<GetPurchaseOrderDto>> GetAllPurchaseOrderDtos()
        {
            return new SuccessDataResult<List<GetPurchaseOrderDto>>(_purchaseOrderDal.GetAllPurchaseOrderDtos());
        }

        public IDataResult<GetPurchaseOrderDto> GetByIdPurchaseOrderDto(int id)
        {
            return new SuccessDataResult<GetPurchaseOrderDto>(_purchaseOrderDal.GetPurchaseOrderDto(x => x.Id == id));
        }

        [ValidationAspect(typeof(PurchaseOrderValidator))]
        public IResult Add(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderDal.Add(purchaseOrder);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderDal.Delete(purchaseOrder);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(PurchaseOrderValidator))]
        public IResult Update(PurchaseOrder purchaseOrder)
        {
            _purchaseOrderDal.Update(purchaseOrder);
            return new SuccessResult(Messages.Modified);
        }
        //private readonly ITallyInProviderFactory _purchaseOrderProviderFactory;

        //public PurchaseOrderManager(ITallyInProviderFactory purchaseOrderProviderFactory)
        //{
        //    _purchaseOrderProviderFactory = purchaseOrderProviderFactory;
        //}

        //public IDataResult<List<GetPurchaseOrderDto>> GetAllPurchaseOrders()
        //{
        //    return new SuccessDataResult<List<GetPurchaseOrderDto>>(_purchaseOrderProviderFactory.Create()
        //        .PurchaseOrderDal.GetAllPurchaseOrderDtos());
        //}

        //public IDataResult<GetPurchaseOrderDto> GetPurchaseOrder(int id)
        //{
        //    return new SuccessDataResult<GetPurchaseOrderDto>(_purchaseOrderProviderFactory.Create().PurchaseOrderDal
        //        .GetPurchaseOrderDto(x => x.Id == id));
        //}

        //public IDataResult<PurchaseOrder> GetByIdPurchaseOrder(int id)
        //{
        //    return new SuccessDataResult<PurchaseOrder>(_purchaseOrderProviderFactory.Create().PurchaseOrderDal
        //        .Get(x => x.Id == id));
        //}

        //[ValidationAspect(typeof(LedgerValidator))]
        //[ValidationAspect(typeof(PurchaseOrderValidator))]
        //[ValidationAspect(typeof(PurchaseOrderLineValidator))]
        //[TransactionScopeAspect]
        //public IResult AddPurchaseOrder(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines)
        //{
        //    _purchaseOrderProviderFactory.Create().LedgerDal.Add(ledger);
        //    purchaseOrder.LedgerId = ledger.Id;
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderDal.Add(purchaseOrder);
        //    foreach (var purchaseOrderLine in purchaseOrderLines)
        //    {
        //        purchaseOrderLine.PurchaseOrderId = purchaseOrder.Id;
        //    }
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderLineDal.BulkInsert(purchaseOrderLines);
        //    return new SuccessResult(Messages.Added);
        //}
        //[TransactionScopeAspect]
        //public IResult DeletePurchaseOrder(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines)
        //{
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderLineDal.BulkDelete(purchaseOrderLines);
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderDal.Delete(purchaseOrder);
        //    _purchaseOrderProviderFactory.Create().LedgerDal.Delete(ledger);
        //    return new SuccessResult(Messages.Deleted);
        //}

        //[TransactionScopeAspect]
        //[ValidationAspect(typeof(LedgerValidator))]
        //[ValidationAspect(typeof(PurchaseOrderValidator))]
        //[ValidationAspect(typeof(PurchaseOrderLineValidator))]
        //public IResult UpdatePurchaseOrder(Ledger ledger, PurchaseOrder purchaseOrder, List<PurchaseOrderLine> purchaseOrderLines)
        //{
        //    _purchaseOrderProviderFactory.Create().LedgerDal.Update(ledger);
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderDal.Update(purchaseOrder);
        //    _purchaseOrderProviderFactory.Create().PurchaseOrderLineDal.BulkSynchronize(purchaseOrderLines);
        //    return new SuccessResult(Messages.Modified);
        //}

    }
}
