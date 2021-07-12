namespace DataAccess.Extensions
{
    using Entity.Concrete;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ModelBuilderFinancialExtensions" />.
    /// </summary>
    public static class ModelBuilderFinancialExtensions
    {
        /// <summary>
        /// The AccountSeed.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        public static void AccountSeed(this ModelBuilder modelBuilder)
        {
            //Account Type Initial
            modelBuilder.Entity<AccountType>().HasData(new List<AccountType> {
                new AccountType{Id=1,Name="Varliklar", Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new AccountType{Id=2,Name="Kaynaklar",Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new AccountType{Id=3,Name="Yukumlulukler",Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new AccountType{Id=4,Name="Gelirler",Description=null,Created=DateTime.Now,Modified=DateTime.Now},
                new AccountType{Id=5,Name="Giderler",Description=null, Created = DateTime.Now, Modified = DateTime.Now }
            });
        }
    }
}
