using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Comments
{
    /// <summary>
    /// نظرات کالاها
    /// </summary>
    public class Comment : BaseEntity<long>
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// تاریخ درج
        /// </summary>
        public DateTime InsertDate { get; set; }




        /// <summary>
        /// کالا
        /// </summary>
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }




        /// <summary>
        /// والد
        /// </summary>
        public long? ParentId { get; set; }
        public virtual Comment Parent { get; set; }


        /// <summary>
        /// فرزندان
        /// </summary>
        public virtual IList<Comment> Comments { get; set; }


        /// <summary>
        /// کاربر
        /// </summary>
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<CommentVote> CommentVote { get; set; }
    }
}
