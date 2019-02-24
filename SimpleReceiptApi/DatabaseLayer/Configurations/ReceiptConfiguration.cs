using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(au => au.CreatedOn).HasDefaultValueSql("getdate()");

            builder
                .HasOne(x => x.Table)
                .WithMany(y => y.Receipts)
                .HasForeignKey(z => z.TableId);

            builder
                .HasOne(x => x.Waiter)
                .WithMany(y => y.Receipts)
                .HasForeignKey(z => z.WaiterId);

            builder
                .HasOne(x => x.Cafe)
                .WithMany(y => y.Receipts)
                .HasForeignKey(z => z.CafeId);
        }
    }
}
