namespace TheWindCorner.Data.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    using TheWindCorner.Data.Models.Entities.Contracts;
    using TheWindCorner.Data.Models.Entities.Enums;
    using TheWindCorner.Data.Models.User;
    using TheWindCorner.Web.Infrastructure.Attributes;

    using static TheWindCorner.Common.EntityValidationConstants.Item;
    using static TheWindCorner.Common.EntityValidationMessages.Item;


    [Comment("Item listed for sale")]
    public class Item : INotifiableEntity
    {

        [Key]
        [Comment("Item Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("The Category of the Item")]
        public Category Category { get; set; }

        [Required]
        [Comment("The Type of the Item")]
        public ItemType ItemType { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("A short descriptive title for the item")]
        public string Title { get; set; } = null!;

        [MaxLength(SizeMaxLength)]
        [Comment("The Size of the Item")]
        public string? Size { get; set; }
             
        [MaxLength(BrandMaxLength)]
        [Comment("The Brand Name of the Item")]
        public string? Brand { get; set; }

        [MaxLength(ModelMaxLength)]
        [Comment("The Model Name of the Item")]
        public string? Model { get; set; }

        [Required]
        [RangeUntilCurrentYear(MinYear, ErrorMessage = YearValidationMassage)]
        [Comment("The Year of the Item's production or collection")]
        public int Year { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Comment("The Price of the Item")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("A full description of the item")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The date and time, when the item was listed for sale")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("If the Item has been approved for listing")]
        public bool IsApproved { get; set; } = false;

        [Required]
        [Comment("If the Item has been sold")]
        public bool IsSold { get; set; } = false;
        
        [Required]
        [Comment("If the Item has been deleted")]
        public bool IsDeleted { get; set; } = false;


        [Required]
        [Comment("The Identifier of the Item's Owner")]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [Comment("The Owner of the Item")]
        public virtual ApplicationUser Owner { get; set; } = null!;


        [Comment("All images of the item")]
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

        [Comment("All the comments made on the item")]
        public virtual ICollection<ItemComment> Comments { get; set; } = new HashSet<ItemComment>();

    }
}

