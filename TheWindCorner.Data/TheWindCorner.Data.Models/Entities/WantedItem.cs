namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TheWindCorner.Data.Models.Entities.Contracts;
    using TheWindCorner.Data.Models.User;

    using static TheWindCorner.Common.EntityValidationConstants.Item;


    [Comment("Item that an user is looking for")]
    public class WantedItem : INotifiableEntity
    {

        [Key]
        [Comment("The identifier of the wanted item")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("A short descriptive title for the wanted item")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("A full description of the wanted item")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The date and time, when the sought item was listed")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("If the wanted item has been approved for listing")]
        public bool IsApproved { get; set; } = false;

        [Required]
        [Comment("If the wanted item has been bought")]
        public bool IsBought { get; set; } = false;

        [Required]
        [Comment("If the wanted item has been deleted")]
        public bool IsDeleted { get; set; } = false;


        [Required]
        [Comment("The identifier of the user seeking the item")]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [Comment("The user seeking the item")]
        public virtual ApplicationUser Owner { get; set; } = null!;


        [Comment("All images of the wanted item")]
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

        [Comment("All the comments made on the item")]
        public virtual ICollection<WantedItemComment> Comments { get; set; } = new HashSet<WantedItemComment>();

    }
}
