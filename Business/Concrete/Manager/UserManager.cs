using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Core.Entity.Concrete;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;

namespace Business.Concrete.Manager
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserRegister);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<User> Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessDataResult<User>(Messages.Deleted);
        }

        public IDataResult<User> Update(User user)
        {
            _userDal.Update(user);
            return new SuccessDataResult<User>(Messages.Modified);
        }
    }
}
