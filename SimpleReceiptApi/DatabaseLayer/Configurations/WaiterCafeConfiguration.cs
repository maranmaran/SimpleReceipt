using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLayer.Configurations
{
  
    public class WaiterCafeConfiguration : IEntityTypeConfiguration<WaiterCafe>
    {
        public void Configure(EntityTypeBuilder<WaiterCafe> builder)
        {
            builder
                .HasKey(x => new { x.WaiterId, x.CafeId });

            builder
                .HasOne(x => x.Cafe)
                .WithMany(y => y.Waiters)
                .HasForeignKey(z => z.CafeId);

            builder
                .HasOne(x => x.Waiter)
                .WithMany(y => y.Cafes)
                .HasForeignKey(z => z.WaiterId);
        }
    }
}
