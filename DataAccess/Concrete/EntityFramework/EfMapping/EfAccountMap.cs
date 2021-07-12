using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfAccountMap : BaseEntityMap<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("Accounts", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever()
                 .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasMany(x => x.LedgerEntries)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId);

            builder.HasOne(x => x.AccountType)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.AccountTypeId);

            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
