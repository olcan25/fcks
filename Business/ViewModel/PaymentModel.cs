using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.ViewModel
{
    public class PaymentModel
    {
        public Ledger Ledger { get; set; }
        public Payment Payment { get; set; }
    }

}
