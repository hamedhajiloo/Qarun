using Entities.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Services.Dto.Comments
{
    public class CommentSelectDto:BaseDto<CommentSelectDto,Comment,long>
    {
        /// <summary>
        /// آواتار کاربر
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// نام فرستنده
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// تاریخ درج | یا دریافت
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// عنوان نظر
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// محتوا
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// تعداد پسندیدن
        /// </summary>
        public int Like { get; set; }

        /// <summary>
        /// تعداد نپسندیدن
        /// </summary>
        public int DisLike { get; set; }

        /// <summary>
        /// تعداد پاسخ ها
        /// </summary>
        public int ReplyCount { get; set; }
    }

    public class CommentCreateDto : BaseDto<CommentCreateDto, Comment, long>
    {
        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات")]
        public string Description { get; set; }


        /// <summary>
        /// تاریخ درج
        /// </summary>
        [DisplayName("تاریخ درج")]
        public DateTime InsertDate { get; set; }


        /// <summary>
        /// کالا
        /// </summary>
        [DisplayName("کالا")]
        public long ProductId { get; set; }
    }

    public class CommentLikeOrDislikeDto
    {
        public long Like { get; set; }
        public long DisLike { get; set; }
    }

    public class CommentDetailDto
    {
        public long Id { get; set; }
        public string UserAvatar { get; set; }
        public string SenderName { get; set; }
        public DateTime InsertDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }

        public IList<RepliesCommentServiceModel> Replies { get; set; }

        public class RepliesCommentServiceModel
        {
            public long Id { get; set; }
            public string UserAvatar { get; set; }
            public string SenderName { get; set; }
            public DateTime InsertDate { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int Like { get; set; }
            public int DisLike { get; set; }
        }
    }

    public class CommentsGetUserCommentDto
    {
        public string Content { get; set; }
        public int DisLike { get; set; }
        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int Like { get; set; }
        public string Title { get; set; }
        public int ReplyCount { get; set; }
    }

    public class CommentsGetUserCommentProductDto: CommentsGetUserCommentDto
    {
        public long ProductId { get; set; }
        public string ProductTitle { get; set; }
    }
}
