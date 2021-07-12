using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.IoCHell.Business.Factory.Abstract;
using Business.IoCHell.Business.Provider.Abstract;
using Business.IoCHell.Business.Provider.Concrete;

namespace Business.IoCHell.Business.Factory.Concrete
{
    public class ReportFactory : IReportFactory
    {
        private readonly IProductService _productService;
        private readonly IPartnerService _partnerService;
        private readonly IAccountService _accountService;

        public ReportFactory(IProductService productService, IPartnerService partnerService, IAccountService accountService)
        {
            _productService = productService;
            _partnerService = partnerService;
            _accountService = accountService;
        }

        public IReportProvider Create()
        {
            return new ReportProvider(_productService, _partnerService, _accountService);
        }
    }
}
