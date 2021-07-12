using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Payment;

namespace DataAccess.Abstract
{
    public interface IPaymentDal:IEntityRepository<Payment>
    {
        List<GetPaymentDto> GetAllPaymentDtoJoins(Expression<Func<GetPaymentDto, bool>> filter = null);
        GetPaymentDto GetByIdPaymentDtoJoin(Expression<Func<GetPaymentDto, bool>> filter);
    }
}
