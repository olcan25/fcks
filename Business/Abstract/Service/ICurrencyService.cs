using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface ICurrencyService
    {
        IDataResult<List<Currency>> GetAllCurrencies();
        IDataResult<Currency> GetByIdCurrency(short id);
        IResult Add(Currency currency);
        IResult Delete(Currency currency);
        IResult Update(Currency currency);
    }
}
