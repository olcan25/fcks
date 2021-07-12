using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;

namespace Business.IoCHell.Business.Provider.Abstract
{
    public interface IReportProvider
    {
        IProductService ProductService { get; set; }
        IPartnerService PartnerService { get; set; }
        IAccountService AccountService { get; set; }
    }
}
