using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.ViewModel
{
    public class WholeSaleOrderModel
    {
        public Ledger Ledger { get; set; }
        public WholeSaleOrder WholeSaleOrder { get; set; }
        public List<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
