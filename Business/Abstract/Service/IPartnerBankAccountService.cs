using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.PartnerBankAccount;

namespace Business.Abstract.Service
{
    public interface IPartnerBankAccountService
    {
        IDataResult<List<DtoPartnerBankAccount>> GetAllDtoPartnerBankAccounts();
        IDataResult<DtoPartnerBankAccount> GetByIdDtoPartnerBankAccount(int id);
        IDataResult<PartnerBankAccount> GetForDelete(int id);
        IResult AddPartnerBankAccount(PartnerBankAccount partnerBankAccount);
        IResult DeletePartnerBankAccount(PartnerBankAccount partnerBankAccount);
        IResult UpdatePartnerBankAccount(PartnerBankAccount partnerBankAccount);
    }
}
