namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheWindCorner.Data.Models.Entities.Enums;
    using TheWindCorner.Data.Models.User;


    [Comment("Notification to the admin about user's action")]
    public class Notification
    {

        [Key]
        [Comment("The identifier of the notification")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("The date and time the notification was sent")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Comment("The identifier of the item, that was commented")]
        public Guid EntityId { get; set; }

        [Required]
        [Comment("The type of the entity")]
        public NotifiableEntityType EntityType { get; set; }

        [Required]
        [Comment("The identifier of the user, whose action triggered the notification")]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [Comment("The user, whose action triggered the notification")]
        public virtual ApplicationUser Owner { get; set; } = null!;

    }
}
