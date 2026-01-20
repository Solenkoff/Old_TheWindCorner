namespace TheWindCorner.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TheWindCorner.Data.Models.Entities;
    using TheWindCorner.Data.Models.Entities.Enums;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(EventStatus.Upcoming);

        }
    }
}
