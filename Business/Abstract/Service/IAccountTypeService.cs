using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface IAccountTypeService
    {
        IDataResult<List<AccountType>> GetAllAccountTypesList();
        IDataResult<AccountType> GetByIdAccountTypes(byte id);

    }
}
