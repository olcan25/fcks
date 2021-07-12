using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class PaymentTypeManager:IPaymentTypeService
    {
        private readonly IPaymentTypeDal _paymentTypeDal;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal = paymentTypeDal;
        }


        public IDataResult<List<PaymentType>> GetAllPaymentTypes()
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeDal.GetAll());
        }

        public IDataResult<PaymentType> GetByIdPaymentType(byte id)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(x => x.Id == id));
        }
    }
}
