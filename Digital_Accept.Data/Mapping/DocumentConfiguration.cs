using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digital_Accept.Data.Mapping
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Document");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(200);

            builder.Property(p => p.Description)
               .HasColumnName("Description")
               .HasMaxLength(400);

            builder.Property(p => p.DateHourCriation)
              .IsRequired()
              .HasColumnName("DateHourCriation")
              .HasColumnType("datetime");
        }
    }
}
