using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digital_Accept.Data.Mapping
{
    public class SignataryConfiguration : IEntityTypeConfiguration<Signatary>
    {
        public void Configure(EntityTypeBuilder<Signatary> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Signatary");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(200);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasMaxLength(11);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(200);
        }
    }
}
