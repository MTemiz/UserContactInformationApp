using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Entities;

namespace Report.Infrastructure.Configuration
{
    public class LocationReportResultEntityTypeConfiguration : IEntityTypeConfiguration<LocationReportResult>
    {
        public void Configure(EntityTypeBuilder<LocationReportResult> builder)
        {
            builder.ToTable("LocationReportResult");

            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id).IsUnique();

            builder.Property(c => c.Id)
                    .HasColumnType("uuid")
                    .HasDefaultValueSql("gen_random_uuid()")
                    .IsRequired();

            builder.Property(c => c.CreatedDate).HasColumnType("timestamp without time zone");

            builder.Property(c => c.LastUpdatedDate).HasColumnType("timestamp without time zone");
        }
    }
}
