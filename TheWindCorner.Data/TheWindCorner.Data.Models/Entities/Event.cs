namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheWindCorner.Data.Models.Entities.Enums;

    using static TheWindCorner.Common.EntityValidationConstants.Event;
    using static TheWindCorner.Common.EntityValidationMessages.Event;

    public class Event
    {

        [Key]
        [Comment("Event Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthMassage)]
        [Comment("A short descriptive title for the event")]
        public string Title { get; set; } = null!;
        
        [Required]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMassage)]
        [Comment("A description of the event")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(FullInfoMaxLength, ErrorMessage = FullInfoMaxLengthMassage)]
        [Comment("A full description of the event")]
        public string FullInfo { get; set; } = null!;

        [Required]
        [Comment("The date and time, when the event starts")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("The date and time, when the event ends")]
        public DateTime End { get; set; }

        [Required]
        [MaxLength(LocationMaxLength, ErrorMessage = LocationMaxLengthMassage)]
        [Comment("The location, where the event is to be held")]
        public string Location { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(EventStatus))]
        [Comment("The status of the event")]
        public EventStatus Status { get; set; } = EventStatus.Upcoming;

        [Comment("The Identifier of the spot, where the event takes place")]
        public Guid? SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        [Comment("The spot, where the event takes place")]
        public Spot? Spot { get; set; }

        [Comment("All images of the event")]
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

        [Comment("All the comments made on the event")]
        public virtual ICollection<EventComment> Comments { get; set; } = new HashSet<EventComment>();

    }
}
