using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto.LedgerEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ILedgerEntryDal : IEntityRepository<LedgerEntry>
    {
        List<LedgerAccountDto> GetAllLedgerAccountsDto(Expression<Func<LedgerAccountDto, bool>> filter = null);
        LedgerAccountDto GetByLEdgerAccountDto(Expression<Func<LedgerAccountDto, bool>> filter);
    }
}
