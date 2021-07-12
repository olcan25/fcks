using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.IoCHell.Business.Provider.Abstract;

namespace Business.IoCHell.Business.Factory.Abstract
{
    public interface IPaymentFactory
    {
        IPaymentProvider Create();
    }
}
