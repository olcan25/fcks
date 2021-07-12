using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;

namespace Business.IoCHell.Business.Provider.Abstract
{
    public interface ITallyOutProvider
    {
        ILedgerService LedgerService { get; set; }
        IWholeSaleOrderService WholeSaleOrderService { get; set; }
        IWholeSaleOrderLineService WholeSaleOrderLineService { get; set; }
        IPaymentService PaymentService { get; set; }
        ILedgerEntryService LedgerEntryService { get; set; }
        IProductService ProductService { get; set; }
    }
}
