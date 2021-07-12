using System.IO;
using System.Reflection;
using Core.Entity.Concrete;
using DataAccess.Extensions;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class InventoryManagementContext : DbContext
    {
        public static IConfiguration Configuration { get; set; }

        private string GetConncetionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.GetConnectionString("fcdDB");
        }
        public InventoryManagementContext()
        {

            if (Database.EnsureCreated())
            {
                Database.EnsureCreated();
                InitialDatabase.InitialDatabase.InitDatabase();
            }
            else
            {
                return;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.;Database=fcdDB;Integrated Security=true;");
            optionsBuilder.UseSqlServer(GetConncetionString());
            //optionsBuilder.UseNpgsql(GetConncetionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Seed();
            modelBuilder.AccountSeed();
        }


        public DbSet<Log> Logs { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerBankAccount> PartnerBankAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyBankAccount> CompanyBankAccounts { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<LedgerEntry> LedgerEntries { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseType> WarehouseTypes { get; set; }
        public DbSet<WholeSaleOrder> WholeSaleOrders { get; set; }
        public DbSet<WholeSaleOrderLine> WholeSaleOrderLines { get; set; }
    }
}
