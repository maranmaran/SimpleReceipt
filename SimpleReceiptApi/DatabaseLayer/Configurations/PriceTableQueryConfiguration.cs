using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class PriceTableQueryConfiguration : IEntityTypeConfiguration<PriceTableQuery>
    {
        public void Configure(EntityTypeBuilder<PriceTableQuery> builder)
        {
            builder
                .HasOne(x => x.Product)
                .WithMany(y => y.PriceTableQueries)
                .HasForeignKey(z => z.ProductId);

            builder
                .HasOne(x => x.PriceTable)
                .WithMany(y => y.PriceTableQueries)
                .HasForeignKey(z => z.PriceTableId);
        }
    }
}
