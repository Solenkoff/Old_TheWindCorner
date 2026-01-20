namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static TheWindCorner.Common.EntityValidationConstants.Image;

    public class Image
    {

        [Key]
        [Comment("Image Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(TitleMaxLength)]
        [Comment("A short descriptive title for the image")]
        public string? Title { get; set; }

        [MaxLength(TextMaxLength)]
        [Comment("Text added to the image")]
        public string? Text { get; set; }

        [Required]
        [Comment("The path to the image")]
        public string Path { get; set; } = null!;


        [Comment("The identifier of the related item")]
        public Guid? ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [Comment("The related item")]
        public virtual Item? Item { get; set; }


        [Comment("The identifier of the related wanted item")]
        public Guid? WantedItemId { get; set; }

        [ForeignKey(nameof(WantedItemId))]
        [Comment("The related wanted item")]
        public virtual WantedItem? WantedItem { get; set; }


        [Comment("The identifier of the related spot")]
        public Guid? SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        [Comment("The related spot")]
        public virtual Spot? Spot { get; set; }


        [Comment("The identifier of the related event")]
        public Guid? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The related event")]
        public virtual Event? Event { get; set; }



    }
}
