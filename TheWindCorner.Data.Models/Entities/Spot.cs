namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TheWindCorner.Data.Models.Entities.Contracts;
    using TheWindCorner.Data.Models.User;

    using static TheWindCorner.Common.EntityValidationConstants.Spot;
    using static TheWindCorner.Common.EntityValidationMessages.Spot;


    [Comment("A location, where one of the wind-sports can be practiced")]
    public class Spot : INotifiableEntity
    {
        [Key]
        [Comment("The identifier of the spot")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthMessage)]
        [Comment("The name of the spot")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMessage)]
        [Comment("A full description of the spot")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(-90, 90, ErrorMessage = LatitudeValidationMessage)]
        [Comment("The latitude of the spot's location")]
        public double? Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = LongitudeValidationMessage)]
        [Comment("The longitude of the spot's location")]
        public double? Longitude { get; set; }

        [Required]
        [Comment("The date and time, when the spot was added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Comment("If the spot has been approved for listing")]
        public bool IsApproved { get; set; } = false;
        
        [Required]
        [Comment("If the spot has been deleted")]
        public bool IsDeleted { get; set; } = false;


        [Required]
        [Comment("The identifier of the user, who added this spot")]
        public Guid AddedByUserId { get; set; }

        [ForeignKey(nameof(AddedByUserId))]
        [Comment("The user, who added this spot")]
        public virtual ApplicationUser AddedByUser { get; set; } = null!; 


        [Comment("All users who have this as their home spot")]
        public virtual ICollection<ApplicationUser> HomeSpotUsers { get; set; } = new HashSet<ApplicationUser>();

        [Comment("All images of the spot")]
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

        [Comment("All events that take place on this spot")]
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();

        [Comment("All the comments made on the item")]
        public virtual ICollection<SpotComment> Comments { get; set; } = new HashSet<SpotComment>();

    }
}
