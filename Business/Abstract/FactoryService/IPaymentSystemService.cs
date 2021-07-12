using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.FactoryService
{
    public interface IPaymentSystemService
    {
        IResult Add(Ledger ledger, Payment payment);
        IResult Delete(int id);
        IResult Update(Ledger ledger, Payment payment);
    }
}
