using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Comments
{
    public class CommentVote : BaseEntity<long>
    {
        /// <summary>
        /// امتیاز
        /// </summary>
        public Vote Vote { get; set; }


        public long CommentId { get; set; }
        public virtual Comment Comment { get; set; }


        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
    #region Config

    public class CommentVoteConfiguration : IEntityTypeConfiguration<CommentVote>
    {
        public void Configure(EntityTypeBuilder<CommentVote> builder)
        {
            builder.HasIndex(p => new { p.CommentId, p.UserId }).IsUnique().HasName("Comment_Vote_Group");
        }
    }

    #endregion Config
}
