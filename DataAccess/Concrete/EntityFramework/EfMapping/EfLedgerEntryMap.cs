using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class EfLedgerEntryMap : BaseEntityMap<LedgerEntry>
    {
        public override void Configure(EntityTypeBuilder<LedgerEntry> builder)
        {
            base.Configure(builder);

            builder.ToTable("LedgerEntries", "Accounting");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Ledger)
                .WithMany(x => x.LedgerEntries)
                .HasForeignKey(x => x.LedgerId);

            builder.HasOne(x => x.Account)
                .WithMany(x => x.LedgerEntries)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
