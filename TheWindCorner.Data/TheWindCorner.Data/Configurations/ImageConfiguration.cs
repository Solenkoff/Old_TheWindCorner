namespace TheWindCorner.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using TheWindCorner.Data.Models.Entities;

    using static TheWindCorner.Common.EntityValidationConstants.Image;


    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {

        public void Configure(EntityTypeBuilder<Image> builder)
        {

            builder.HasKey(i => i.Id);

            builder
                .HasOne(i => i.Item)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.WantedItem)
                .WithMany(w => w.Images)
                .HasForeignKey(i => i.WantedItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Spot)
                .WithMany(s => s.Images)
                .HasForeignKey(i => i.SpotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Event)
                .WithMany(e => e.Images)
                .HasForeignKey(i => i.EventId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Image_OnlyOneParent",
                    @"(
                (CASE WHEN ""ItemId"" IS NOT NULL THEN 1 ELSE 0 END) +
                (CASE WHEN ""SpotId"" IS NOT NULL THEN 1 ELSE 0 END) +
                (CASE WHEN ""EventId"" IS NOT NULL THEN 1 ELSE 0 END) +
                (CASE WHEN ""WantedItemId"" IS NOT NULL THEN 1 ELSE 0 END)
              ) = 1"
                );
            });


            builder.Property(i => i.Title)
                .HasMaxLength(TitleMaxLength);

            builder.Property(i => i.Text)
                .HasMaxLength(TextMaxLength);

            builder.Property(i => i.Path)
                .IsRequired();

        }

    }
}
