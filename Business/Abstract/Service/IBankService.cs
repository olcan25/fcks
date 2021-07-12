using System.Collections.Generic;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
     public interface IBankService
    {
        IDataResult<List<Bank>> GetAllBanks();
        IDataResult<Bank> GetByIdBank(int id);
        IResult AddBank(Bank bank);
        IResult DeleteBank(Bank bank);
        IResult UpdateBank(Bank bank);
    }
}
