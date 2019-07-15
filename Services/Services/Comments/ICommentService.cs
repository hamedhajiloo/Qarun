using Common;
using Entities.Comments;
using Entities.Enums;
using Services.Dto.Comments;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public interface ICommentService
    {
        /// <summary>
        /// ثبت نظر برای محصول
        /// </summary>
        /// <param name="productId">شناسه محصول</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <param name="title">عنوان</param>
        /// <param name="content">متن</param>
        /// <param name="parentId">والد</param>
        Task AddCommentAsync(long productId, string userId, string title, string content, long? parentId,CancellationToken cancellationToken);

        /// <summary>
        /// لیست نظرات یک محصول جهت نمایش
        /// </summary>
        /// <param name="productId">شناسه محصول</param>
        /// <param name="pager"></param>
        /// <returns></returns>
        Task<IEnumerable<CommentSelectDto>> GetCommentsAsync(long productId, Pager pager, CancellationToken cancellationToken);

        /// <summary>
        /// تعداد نظرات یک محصول
        /// </summary>
        /// <param name="productId">شناسه محصول</param>
        /// <returns></returns>
        Task<int> CountCommentsAsync(long productId, CancellationToken cancellationToken);
      

        /// <summary>
        /// لایک و دیس لایک نظر محصول
        /// </summary>
        /// <returns></returns>
        Task LikeOrDisLikeAsync(string userId, long commentId, Vote vote, CancellationToken cancellationToken);

        /// <summary>
        /// جمع تعداد لایک و دیس لایک
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Task<CommentLikeOrDislikeDto> LikeOrDisLikeResaultAsync(long commentId, CancellationToken cancellationToken);

        /// <summary>
        /// جزئیات نظر
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Task<CommentDetailDto> GetDetailsAsync(long commentId, CancellationToken cancellationToken);

        /// <summary>
        /// ليست کامنت هايي که يک کاربر به کل محصولات داده است
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        Task<List<CommentsGetUserCommentProductDto>> GetUserCommentsAsync(string userId, Pager pager, CancellationToken cancellationToken);

        /// <summary>
        /// تعداد نظرات يک کاربر به کل محصولات داده است
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetUserCommentsCountAsync(string userId, CancellationToken cancellationToken);

        Task<Comment> FindByIdAsync(long commentId, CancellationToken cancellationToken);
    }
}
