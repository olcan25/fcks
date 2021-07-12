using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Partner;

namespace Business.Abstract.Service
{
    public interface IPartnerService
    {
        IDataResult<List<Partner>> GetAllPartners();
        IDataResult<Partner> GetByIdPartner(int id);
        IDataResult<List<DtoConditionOfPartner>> GetAllConditionOfPartners();
        IDataResult<List<DtoConditionOfPartner>> GetAllConditionOfPartners(DateTime startDate, DateTime endDate);
        IDataResult<List<DtoCardOfPartner>> GetAllCardOfPartners(int partnerId);
        IDataResult<List<DtoCardOfPartner>> GetAllCardOfPartners(int partnerId, DateTime startDate, DateTime endDate);
        IResult AddPartner(Partner partner);
        IResult DeletePartner(Partner partner);
        IResult UpdatePartner(Partner partner);
    }
}
