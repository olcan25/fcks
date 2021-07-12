using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.IoCHell.Business.Provider.Abstract;

namespace Business.IoCHell.Business.Provider.Concrete
{
    public class ReportProvider : IReportProvider
    {
        public IProductService ProductService { get; set; }
        public IPartnerService PartnerService { get; set; }
        public IAccountService AccountService { get; set; }

        public ReportProvider(IProductService productService, IPartnerService partnerService, IAccountService accountService)
        {
            ProductService = productService;
            PartnerService = partnerService;
            AccountService = accountService;
        }
    }
}
