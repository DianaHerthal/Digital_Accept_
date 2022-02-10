using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digital_Accept.Data.Mapping
{
    public class SignatureConfiguration : IEntityTypeConfiguration<Signature>
    {
        public void Configure(EntityTypeBuilder<Signature> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Signature");

            builder.Property(p => p.Accept);

            builder.Property(p => p.DateHourRegister)
                .IsRequired()
                .HasColumnName("DateHourRegister")
                .HasColumnType("datetime");

            builder.HasOne(e => e.SignataryDocument)
                .WithOne(d => d.Signature)
                .HasForeignKey<Signature>(e => e.SignataryDocumentId)
                .HasConstraintName("FK_SignataryDocument_Signature_SignataryDocumentId");
        }
    }
}
