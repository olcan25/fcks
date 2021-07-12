using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.Partner;

namespace DataAccess.Abstract
{
    public interface IPartnerDal : IEntityRepository<Partner>
    {
        List<DtoConditionOfPartner> GetAllConditionOfPartners(
            Expression<Func<DtoConditionOfPartner, bool>> filter = null);
        List<DtoConditionOfPartner> GetAllConditionOfPartners(DateTime startDate, DateTime endDate,
    Expression<Func<DtoConditionOfPartner, bool>> filter = null);

        List<DtoCardOfPartner> GetAllCardOfPartners(Expression<Func<DtoCardOfPartner, bool>> filter = null);

    }
}
