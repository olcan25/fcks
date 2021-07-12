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
using Entity.Dto.Invoice;
using Entity.Dto.WholeSaleOrder;

namespace Business.Concrete.Manager
{
    public class WholeSaleOrderManager : IWholeSaleOrderService
    {
        private readonly IWholeSaleOrderDal _wholeSaleOrderDal;

        public WholeSaleOrderManager(IWholeSaleOrderDal wholeSaleOrderDal)
        {
            _wholeSaleOrderDal = wholeSaleOrderDal;
        }

        public IDataResult<List<WholeSaleOrder>> GetAllWholeSaleOrders()
        {
            return new SuccessDataResult<List<WholeSaleOrder>>(_wholeSaleOrderDal.GetAll());
        }

        public IDataResult<WholeSaleOrder> GetByIdWholeSaleOrder(int id)
        {
            return new SuccessDataResult<WholeSaleOrder>(_wholeSaleOrderDal.Get(x => x.Id == id));
        }

        public IDataResult<WholeSaleOrder> GetByLedgerIdWholeSaleOrder(long ledgerId)
        {
            return new SuccessDataResult<WholeSaleOrder>(_wholeSaleOrderDal.Get(x => x.LedgerId == ledgerId));
        }

        public IDataResult<List<GetWholeSaleOrderDto>> GetAllWholeSaleOrdersDto()
        {
            return new SuccessDataResult<List<GetWholeSaleOrderDto>>(_wholeSaleOrderDal.GetAllWholeSaleOrdersDto());
        }

        public IDataResult<GetWholeSaleOrderDto> GetByIdWholeSaleOrderDto(int id)
        {
            return new SuccessDataResult<GetWholeSaleOrderDto>(
                _wholeSaleOrderDal.GetWholeSaleOrderDto(x => x.Id == id));
        }

        public IDataResult<List<InvoiceHead>> GetAllInvoiceHeads()
        {
            return new SuccessDataResult<List<InvoiceHead>>(_wholeSaleOrderDal.GetAllInvoiceHeads());
        }

        public IDataResult<InvoiceHead> GetByIdInvoiceHead(int wholeSaleOrderId)
        {
            return new SuccessDataResult<InvoiceHead>(
                _wholeSaleOrderDal.GetByIdInvoiceHead(x=>x.Id==wholeSaleOrderId));
        }
        [ValidationAspect(typeof(WholeSaleOrderValidator))]
        public IResult Add(WholeSaleOrder wholeSaleOrder)
        {
            BusinessRules.Run(CheckIfWholeSaleOrderNumber(wholeSaleOrder.WholeSaleOrderNumber));
            _wholeSaleOrderDal.Add(wholeSaleOrder);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(WholeSaleOrder wholeSaleOrder)
        {
            _wholeSaleOrderDal.Delete(wholeSaleOrder);
            return new SuccessResult(Messages.Deleted);
        }
        
        [ValidationAspect(typeof(WholeSaleOrderValidator))]
        public IResult Update(WholeSaleOrder wholeSaleOrder)
        {
            _wholeSaleOrderDal.Update(wholeSaleOrder);
            return new SuccessResult(Messages.Modified);
        }

        private IResult CheckIfWholeSaleOrderNumber(int wholeSaleOrderNumber)
        {
            var result = _wholeSaleOrderDal.GetIsTrue(x => x.WholeSaleOrderNumber == wholeSaleOrderNumber);
            return result
                ? (IResult)new ErrorResult("Bu fatura Numarasi Zaten Var...")
                : new SuccessResult();
        }
    }
}