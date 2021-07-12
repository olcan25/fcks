using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.EntityDal;

namespace Business.DepedencyResolvers
{
    public class AutofacDataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Finansal Tablolar
            builder.RegisterType<EfAccountDal>().As<IAccountDal>();
            builder.RegisterType<EfAccountTypeDal>().As<IAccountTypeDal>();
            builder.RegisterType<EfLedgerEntryDal>().As<ILedgerEntryDal>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfBankDal>().As<IBankDal>();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();
            builder.RegisterType<EfCompanyBankAccountDal>().As<ICompanyBankAccountDal>();
            builder.RegisterType<EfLedgerDal>().As<ILedgerDal>();
            builder.RegisterType<EfPartnerDal>().As<IPartnerDal>();
            builder.RegisterType<EfPartnerBankAccountDal>().As<IPartnerBankAccountDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfUnitOfMeasureDal>().As<IUnitOfMeasureDal>();
            builder.RegisterType<EfVatDal>().As<IVatDal>();
            builder.RegisterType<EfWarehouseDal>().As<IWarehousesDal>();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();
            builder.RegisterType<EfPartnerTypeDal>().As<IPartnerTypeDal>();
            builder.RegisterType<EfProductTypeDal>().As<IProductTypeDal>();
            builder.RegisterType<EfPaymentTypeDal>().As<IPaymentTypeDal>();
            builder.RegisterType<EfProductBarcodeDal>().As<IProductBarcodeDal>();

            builder.RegisterType<EfPurchaseOrderDal>().As<IPurchaseOrderDal>();
            builder.RegisterType<EfPurchaseOrderLineDal>().As<IPurchaseOrderLineDal>();

            builder.RegisterType<EfWholeSaleOrderDal>().As<IWholeSaleOrderDal>();
            builder.RegisterType<EfWholeSaleOrderLineDal>().As<IWholeSaleOrderLineDal>();

        }
    }
}
