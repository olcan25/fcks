using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Concrete;
using Core.Utilities.Result;

namespace Business.Abstract.Service
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> Delete(User user);
        IDataResult<User> Update(User user);

    }
}
