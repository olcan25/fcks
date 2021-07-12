using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfPartnerTypeDal:EfEntityRepositoryBase<PartnerType,InventoryManagementContext>,IPartnerTypeDal
    {
    }
}
