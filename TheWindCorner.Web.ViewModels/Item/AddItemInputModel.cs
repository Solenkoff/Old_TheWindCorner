namespace TheWindCorner.Web.ViewModels.Item
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using TheWindCorner.Data.Models.Enums;
    using TheWindCorner.Data.Models.Entities;
    using TheWindCorner.Web.Infrastructure.Attributes;

    using static Common.EntityValidationConstants.Item;
    using static Common.EntityValidationMessages.Item;


    public class AddItemInputModel
    {
        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = CategoryValidationMassage)]
        public Category Category { get; set; }

        [Required]
        [EnumDataType(typeof(ItemType), ErrorMessage = TypeValidationMassage)]
        public ItemType ItemType { get; set; }

        [Required]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthMassage)]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthMassage)]
        public string Title { get; set; } = null!;

        [MinLength(SizeMinLength, ErrorMessage = SizeMinLengthMassage)]
        [MaxLength(SizeMaxLength, ErrorMessage = SizeMaxLengthMassage)]
        public string? Size { get; set; }

        [MinLength(BrandMinLength, ErrorMessage = BrandMinLengthMassage)]
        [MaxLength(BrandMaxLength, ErrorMessage = BrandMaxLengthMassage)]
        public string? Brand { get; set; }

        [MaxLength(ModelMaxLength)]
        [MinLength(ModelMinLength)]
        public string? Model { get; set; }

        [Required]
        [RangeUntilCurrentYear(MinYear, ErrorMessage = YearValidationMassage)]
        public int Year { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMassage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMassage)]
        public string Description { get; set; } = null!;

        [Comment("The image of the item")]
        public Image? Image { get; set; }

    }
}

