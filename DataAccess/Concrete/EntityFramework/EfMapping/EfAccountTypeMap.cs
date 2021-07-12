using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfAccountTypeMap : BaseEntityMap<AccountType>
    {
        public override void Configure(EntityTypeBuilder<AccountType> builder)
        {
            base.Configure(builder);

            builder.ToTable("AccountTypes", "Accounting");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.AccountType)
                .HasForeignKey(x => x.AccountTypeId);
        }
    }
}
