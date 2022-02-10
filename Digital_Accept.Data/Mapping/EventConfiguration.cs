using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Digital_Accept.Data.Mapping
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Event");

            builder.HasIndex(p => p.DocumentId);

            builder.Property(p => p.EventType)
               .HasColumnName("EventType")
               .HasConversion(new EnumToNumberConverter<EventType, int>());

            builder.Property(p => p.DateHourEvent)
              .IsRequired()
              .HasColumnName("DateHourEvent")
              .HasColumnType("datetime");

            builder.HasOne(e => e.Document)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.DocumentId)
                .HasConstraintName("FK_Document_Event_DocumentId");
        }
    }
}
