using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IPartnerTypeService
    {
        IDataResult<List<PartnerType>> GetAllPartnerTypes();
        IDataResult<PartnerType> GetByIdPartnerType(byte id);
    }
}
