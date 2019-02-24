using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class ReceiptPriceTableQueryConfiguration : IEntityTypeConfiguration<ReceiptPriceTableQuery>
    {
        public void Configure(EntityTypeBuilder<ReceiptPriceTableQuery> builder)
        {
            builder
                .HasKey(x => new { x.ReceiptId, x.PriceTableQueryId });

            builder
                .HasOne(x => x.Receipt)
                .WithMany(y => y.ReceiptPriceTableQueries)
                .HasForeignKey(z => z.ReceiptId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PriceTableQuery)
                .WithMany(y => y.ReceiptPriceTableQueries)
                .HasForeignKey(z => z.PriceTableQueryId);
        }
    }
}
