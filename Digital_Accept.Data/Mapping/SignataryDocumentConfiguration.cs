using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Digital_Accept.Data.Mapping
{
    public class SignataryDocumentConfiguration : IEntityTypeConfiguration<SignataryDocument>
    {
        public void Configure(EntityTypeBuilder<SignataryDocument> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("SignataryDocument");

            builder.Property(p => p.SignataryType)
                .HasColumnName("SignataryType")
                .HasConversion(new EnumToNumberConverter<SignataryType, int>());

            builder.HasOne(e => e.Document)
               .WithMany(d => d.SignatariesDocuments)
               .HasForeignKey(e => e.DocumentId)
               .HasConstraintName("FK_Document_SignataryDocument_DocumentId");

            builder.HasOne(e => e.Signatary)
                .WithMany(d => d.SignatariesDocuments)
                .HasForeignKey(e => e.SignataryId)
                .HasConstraintName("FK_Signatary_SignataryDocument_SignataryId");
        }
    }
}
