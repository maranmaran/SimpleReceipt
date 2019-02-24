﻿using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
    public class PriceTableConfiguration : IEntityTypeConfiguration<PriceTable>
    {
        public void Configure(EntityTypeBuilder<PriceTable> builder)
        {
            builder
                .HasOne(x => x.Cafe)
                .WithOne(y => y.PriceTable);

            builder
                .HasMany(x => x.PriceTableQueries)
                .WithOne(y => y.PriceTable)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
