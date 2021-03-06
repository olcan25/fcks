﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IPaymentTypeService
    {
        IDataResult<List<PaymentType>> GetAllPaymentTypes();
        IDataResult<PaymentType> GetByIdPaymentType(byte id);
    }
}
