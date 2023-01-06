using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetChallenge.Persistence.DbMappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn(1, 1);


            // relations 
            builder.HasOne(o => o.Company).WithMany(c => c.Orders).HasForeignKey(o => o.CompanyId).OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
