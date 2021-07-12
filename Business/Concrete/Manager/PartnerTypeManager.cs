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
    public class PartnerTypeManager:IPartnerTypeService
    {
        private readonly IPartnerTypeDal _partnerTypeDal;

        public PartnerTypeManager(IPartnerTypeDal partnerTypeDal)
        {
            _partnerTypeDal = partnerTypeDal;
        }


        public IDataResult<List<PartnerType>> GetAllPartnerTypes()
        {
            return new SuccessDataResult<List<PartnerType>>(_partnerTypeDal.GetAll());
        }

        public IDataResult<PartnerType> GetByIdPartnerType(byte id)
        {
            return new SuccessDataResult<PartnerType>(_partnerTypeDal.Get(x => x.Id == id));
        }
    }
}
