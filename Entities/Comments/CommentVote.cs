using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Comments
{
    public class CommentVote : IEntity
    {
        [ForeignKey(nameof(Comment))]
        public long CommentId { get; set; }
        public virtual Comment Comment { get; set; }


        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }



    }
    #region Config

    public class CommentVoteConfiguration : IEntityTypeConfiguration<CommentVote>
    {
        public void Configure(EntityTypeBuilder<CommentVote> builder)
        {
            builder.HasKey(c => new { c.CommentId, c.UserId });
        }
    }

    #endregion Config
}
