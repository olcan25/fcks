using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;

namespace Business.IoCHell.Business.Provider.Abstract
{
    public interface ITallyInProvider
    {
        ILedgerService LedgerService { get; set; }
        IPurchaseOrderService PurchaseOrderService { get; set; }
        IPurchaseOrderLineService PurchaseOrderLineService { get; set; }
        IPaymentService PaymentService { get; set; }
        ILedgerEntryService LedgerEntryService { get; set; }
        IProductService ProductService { get; set; }

    }
}
