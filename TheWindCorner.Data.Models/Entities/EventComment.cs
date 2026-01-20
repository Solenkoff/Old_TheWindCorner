namespace TheWindCorner.Data.Models.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheWindCorner.Data.Models.User;

    using static TheWindCorner.Common.EntityValidationConstants.EventComment;
    using static TheWindCorner.Common.EntityValidationMessages.EventComment;


    [Comment("The comment on an event")]
    public class EventComment
    {

        [Key]
        [Comment("The identifier of the comment made")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(ContentMaxLength, ErrorMessage = ContentMaxLengthMassage)]
        [Comment("The full text of the comment")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("The date and time the comment was added or edited")]
        public DateTime CommentedOn { get; set; }

        [Required]
        [Comment("If the comment has been deleted")]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Comment("The identifier of the user, who made the comment")]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [Comment("The user, who made the comment")]
        public virtual ApplicationUser Owner { get; set; } = null!;

        [Required]
        [Comment("The identifier of the event, that was commented")]
        public Guid EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        [Comment("The event, that was commented")]
        public virtual Event Event { get; set; } = null!;

    }
}
