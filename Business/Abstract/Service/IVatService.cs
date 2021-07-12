using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IVatService
    {
        IDataResult<List<Vat>> GetAllVats();
        IDataResult<Vat> GetByIdVat(byte id);

    }
}
