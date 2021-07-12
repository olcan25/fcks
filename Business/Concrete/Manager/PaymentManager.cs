using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.Payment;

namespace Business.Concrete.Manager
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IDataResult<List<GetPaymentDto>> GetAllListDtoPayments()
        {
            return new SuccessDataResult<List<GetPaymentDto>>(_paymentDal.GetAllPaymentDtoJoins());
        }
        public IDataResult<GetPaymentDto> GetByIdDtoPayment(int id)
        {
            return new SuccessDataResult<GetPaymentDto>(_paymentDal.GetByIdPaymentDtoJoin(x => x.Id == id));
        }

        public IDataResult<Payment> GetByLedgerIdPayment(long ledgerId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(x => x.LedgerId == ledgerId));
        }

        public IDataResult<Payment> GetByIdForDelete(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(x => x.Id == id));
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.Modified);
        }
    }
}
