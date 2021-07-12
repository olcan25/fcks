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
    public class VatManager : IVatService
    {
        private readonly IVatDal _vatDal;

        public VatManager(IVatDal vatDal)
        {
            _vatDal = vatDal;
        }
        public IDataResult<List<Vat>> GetAllVats()
        {
            return new SuccessDataResult<List<Vat>>(_vatDal.GetAll());
        }

        public IDataResult<Vat> GetByIdVat(byte id)
        {
            return new SuccessDataResult<Vat>(_vatDal.Get(x => x.Id == id));
        }
    }
}
