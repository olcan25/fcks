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
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Concrete.Manager
{
    public class WholeSaleOrderLineManager: IWholeSaleOrderLineService
    {
        private readonly IWholeSaleOrderLineDal _wholeSaleOrderLineDal;

        public WholeSaleOrderLineManager(IWholeSaleOrderLineDal wholeSaleOrderLineDal)
        {
            _wholeSaleOrderLineDal = wholeSaleOrderLineDal;
        }

        public IDataResult<List<WholeSaleOrderLine>> GetAllWholeSaleOrderLines()
        {
            return new SuccessDataResult<List<WholeSaleOrderLine>>(_wholeSaleOrderLineDal.GetAll());
        }

        public IDataResult<List<WholeSaleOrderLine>> GetByWholeSaleOrderIdWholeSaleOrderLines(long wholeSaleOrderId)
        {
            return new SuccessDataResult<List<WholeSaleOrderLine>>(
                _wholeSaleOrderLineDal.GetAll(x => x.WholeSaleOrderId == wholeSaleOrderId));
        }

        public IDataResult<List<InvoiceLine>> GetAllInvoiceLines()
        {
            return new SuccessDataResult<List<InvoiceLine>>(_wholeSaleOrderLineDal.GetAllInvoiceLines());
        }

        public IDataResult<List<InvoiceLine>> GetByWholeSaleOrderIdInvoiceLines(long wholeSaleOrderId)
        {
            return new SuccessDataResult<List<InvoiceLine>>(
                _wholeSaleOrderLineDal.GetAllInvoiceLines(x => x.WholeSaleOrderId == wholeSaleOrderId));
        }

        [ValidationAspect(typeof(WholeSaleOrderLineValidator))]
        public IResult Add(WholeSaleOrderLine wholeSaleOrderLine)
        {
            _wholeSaleOrderLineDal.Add(wholeSaleOrderLine);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(WholeSaleOrderLine wholeSaleOrderLine)
        {
            _wholeSaleOrderLineDal.Delete(wholeSaleOrderLine);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(WholeSaleOrderLineValidator))]
        public IResult Update(WholeSaleOrderLine wholeSaleOrderLine)
        {
            _wholeSaleOrderLineDal.Update(wholeSaleOrderLine);
            return new SuccessResult(Messages.Modified);
        }
        
        [ValidationAspect(typeof(WholeSaleOrderLineValidator))]
        public IResult BulkAdd(List<WholeSaleOrderLine> wholeSaleOrderLines)
        {
            _wholeSaleOrderLineDal.BulkInsert(wholeSaleOrderLines);
            return new SuccessResult(Messages.Added);
        }

        public IResult BulkDelete(List<WholeSaleOrderLine> wholeSaleOrderLines)
        {
            _wholeSaleOrderLineDal.BulkDelete(wholeSaleOrderLines);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(WholeSaleOrderLineValidator))]
        public IResult BulkUpdate(List<WholeSaleOrderLine> wholeSaleOrderLines)
        {
            _wholeSaleOrderLineDal.BulkSynchronize(wholeSaleOrderLines);
            return new SuccessResult(Messages.Modified);
        }
    }
}
