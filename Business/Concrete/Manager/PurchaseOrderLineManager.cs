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
    public class PurchaseOrderLineManager:IPurchaseOrderLineService
    {
        private readonly IPurchaseOrderLineDal _purchaseOrderLineDal;

        public PurchaseOrderLineManager(IPurchaseOrderLineDal purchaseOrderLineDal)
        {
            _purchaseOrderLineDal = purchaseOrderLineDal;
        }

        public IDataResult<List<PurchaseOrderLine>> GetAllPurchaseOrderLines()
        {
            return new SuccessDataResult<List<PurchaseOrderLine>>(_purchaseOrderLineDal.GetAll());
        }

        public IDataResult<List<PurchaseOrderLine>> GetByPurchaseOrderIdPurchaseOrderLines(long purchaseOrderId)
        {
            return new SuccessDataResult<List<PurchaseOrderLine>>(
                _purchaseOrderLineDal.GetAll(x => x.PurchaseOrderId == purchaseOrderId));
        }

        [ValidationAspect(typeof(PurchaseOrderLineValidator))]
        public IResult Add(PurchaseOrderLine purchaseOrderLine)
        {
            _purchaseOrderLineDal.Add(purchaseOrderLine);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(PurchaseOrderLine purchaseOrderLine)
        {
            _purchaseOrderLineDal.Delete(purchaseOrderLine);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(PurchaseOrderLineValidator))]
        public IResult Update(PurchaseOrderLine purchaseOrderLine)
        {
            _purchaseOrderLineDal.Update(purchaseOrderLine);
            return new SuccessResult(Messages.Modified);
        }

        [ValidationAspect(typeof(PurchaseOrderLineValidator))]
        public IResult BulkAdd(List<PurchaseOrderLine> purchaseOrderLines)
        {
            _purchaseOrderLineDal.BulkInsert(purchaseOrderLines);
            return new SuccessResult(Messages.Added);
        }

        public IResult BulkDelete(List<PurchaseOrderLine> purchaseOrderLines)
        {
            _purchaseOrderLineDal.BulkDelete(purchaseOrderLines);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(PurchaseOrderLineValidator))]
        public IResult BulkUpdate(List<PurchaseOrderLine> purchaseOrderLines)
        {
            _purchaseOrderLineDal.BulkSynchronize(purchaseOrderLines);
            return new SuccessResult(Messages.Modified);
        }
    }
}
