using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Infrastructure.Configuration
{
    public class LocationReportEntityTypeConfiguration : IEntityTypeConfiguration<LocationReport>
    {
        public void Configure(EntityTypeBuilder<LocationReport> builder)
        {
            builder.ToTable("LocationReport");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id).IsUnique();

            builder.Property(c => c.Id)
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()")
                    .IsRequired();

            builder.Property(c => c.RequestedDate).HasColumnType("timestamp without time zone");

            builder.Property(c => c.CreatedDate).HasColumnType("timestamp without time zone");

            builder.Property(c => c.LastUpdatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
