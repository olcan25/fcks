using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Payment;

namespace Business.Abstract.Service
{
    public interface IPaymentService
    {
        IDataResult<List<GetPaymentDto>> GetAllListDtoPayments();
        IDataResult<GetPaymentDto> GetByIdDtoPayment(int id);
        IDataResult<Payment> GetByLedgerIdPayment(long ledgerId);
        IDataResult<Payment> GetByIdForDelete(int id);
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
    }
}
