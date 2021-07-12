using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace DataAccess.Concrete.EntityFramework.InitialDatabase
{
    public static class InitialDatabase
    {
        public static void InitDatabase()
        {

            var accounts = new List<Account>
            {
                //Uc Haneli
                //Aktiv
                new Account{Id="100000",Name="Kasa", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
               // new Account{Id=101000,Name="Bankalar", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                //new Account{Id="102000",Name="POS", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                new Account{Id="120000",Name="Alicilar", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                new Account{Id="191008",Name="Indirilecek KDV %8", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new Account{Id="191018",Name="Indirilecek KDV %18", AccountTypeId=1,Status=true,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                //Pasiv


                new Account{Id="320000",Name="Saticilar", AccountTypeId=3,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                new Account{Id="391008",Name="Hesaplana KDV %8", AccountTypeId=3,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new Account{Id="391018",Name="Hesaplana KDV %18", AccountTypeId=3,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                new Account{Id="500000",Name="Sermaye", AccountTypeId=2,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

                new Account{Id="600018",Name="Gelirler %18", AccountTypeId=6,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new Account{Id="600008",Name="Gelirler %8", AccountTypeId=6,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new Account{Id="600000",Name="Gelirler %0", AccountTypeId=6,Status=false,Description=null,Created=DateTime.Now,Modified=DateTime.Now},

            };
            using var context = new InventoryManagementContext();
            context.BulkInsert(accounts);
        }
    }
}
