using Autofac;
using Business.LedgerEntryCalculation.Abstract;
using Business.LedgerEntryCalculation.Concrete;
using Business.LedgerEntryCalculation.Facade.Abstract;
using Business.LedgerEntryCalculation.Facade.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DepedencyResolvers
{
    public class AutofacFinancialFacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TallyInFinancialManager>().As<ITallyInFinancialService>();
            builder.RegisterType<TallyInFacade>().As<ITallyInFacade>();

            builder.RegisterType<TallyOutFinancialManager>().As<ITallyOutFinancialService>();
            builder.RegisterType<TallyOutFacadeManager>().As<ITallyOutFacadeService>();

            builder.RegisterType<PaymentFinancialManager>().As<IPaymentFinancialService>();
            builder.RegisterType<PaymentFacade>().As<IPaymentFacade>();
        }
    }
}
