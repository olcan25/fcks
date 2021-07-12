using System.IdentityModel.Tokens.Jwt;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract.FactoryService;
using Business.Abstract.Service;
using Business.Concrete;
using Business.Concrete.FactoryManager;
using Business.Concrete.Manager;
using Castle.DynamicProxy;
using Core.Utilities.FileUpload;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;

namespace Business.DepedencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Finansal Tablolar
            builder.RegisterType<AccountManager>().As<IAccountService>();
            builder.RegisterType<AccountTypeManager>().As<IAccountTypeService>();
            builder.RegisterType<LedgerEntryManager>().As<ILedgerEntryService>();

            //User Giris Kayit Icin
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            builder.RegisterType<BankManager>().As<IBankService>();
            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<CompanyBankAccountManager>().As<ICompanyBankAccountService>();
            builder.RegisterType<LedgerManager>().As<ILedgerService>();
            builder.RegisterType<WarehouseManager>().As<IWarehousesService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<UnitOfMeasureManager>().As<IUnitOfMeasureService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<VatManager>().As<IVatService>();
            builder.RegisterType<PartnerManager>().As<IPartnerService>();
            builder.RegisterType<PartnerBankAccountManager>().As<IPartnerBankAccountService>();
            builder.RegisterType<WholeSaleOrderManager>().As<IWholeSaleOrderService>();
            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>();
            builder.RegisterType<ProductTypeManager>().As<IProductTypeService>();
            builder.RegisterType<PartnerTypeManager>().As<IPartnerTypeService>();
            builder.RegisterType<ProductBarcodeManager>().As<IProductBarcodeService>();

            builder.RegisterType<InvoiceManager>().As<IInvoiceService>();

            builder.RegisterType<PurchaseOrderLineManager>().As<IPurchaseOrderLineService>();
            builder.RegisterType<WholeSaleOrderLineManager>().As<IWholeSaleOrderLineService>();

            builder.RegisterType<TallyOutManager>().As<ITallyOutService>();

            builder.RegisterType<TallyInManager>().As<ITallyInService>();

            builder.RegisterType<LedgerAccountManager>().As<ILedgerAccountService>();

            builder.RegisterType<FileUploadHelper>().As<IFileUploadHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
