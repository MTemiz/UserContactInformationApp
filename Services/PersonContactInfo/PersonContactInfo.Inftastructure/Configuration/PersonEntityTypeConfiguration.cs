using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonContactInfo.Domain.Entities;

namespace PersonContactInfo.Inftastructure.Configuration
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

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
