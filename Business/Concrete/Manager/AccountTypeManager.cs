using Business.Abstract.Service;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class AccountTypeManager : IAccountTypeService
    {
        private readonly IAccountTypeDal _accountTypeDal;
        public AccountTypeManager(IAccountTypeDal accountTypeDal)
        {
            _accountTypeDal = accountTypeDal;
        }
        public IDataResult<List<AccountType>> GetAllAccountTypesList()
        {
            return new SuccessDataResult<List<AccountType>>(_accountTypeDal.GetAll());
        }

        public IDataResult<AccountType> GetByIdAccountTypes(byte id)
        {
            return new SuccessDataResult<AccountType>(_accountTypeDal.Get(x => x.Id == id));
        }
    }
}
