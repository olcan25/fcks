using Business.IoCHell.Business.Provider.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IoCHell.Business.Factory.Abstract
{
    public interface ILedgerAccountFactory
    {
        ILedgerAccountProvider Create();
    }
}
