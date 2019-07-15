using Common;
using Common.Utilities;
using Data.Repositories;
using Entities;
using Entities.Comments;
using Entities.Enums;
using Entities.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Dto.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<CommentVote> _commontVoteRepo;
        private readonly IRepository<DefaultLogo> _defaultLogoRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(IRepository<Comment> commentRepo,
            IRepository<Product> productRepo,
            IHttpContextAccessor httpContextAccessor,
            IRepository<DefaultLogo> defaultLogoRepo,
            IRepository<CommentVote> commontVoteRepo)
        {
            _commentRepo = commentRepo;
            _productRepo = productRepo;
            _httpContextAccessor = httpContextAccessor;
            _defaultLogoRepo = defaultLogoRepo;
            _commontVoteRepo = commontVoteRepo;
        }


        /// <summary>
        /// ثبت نظر برای محصول
        /// </summary>
        /// <param name="productId">شناسه محصول</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <param name="title">عنوان</param>
        /// <param name="content">متن</param>
        /// <param name="parentId">نظر والد</param>
        public async Task AddCommentAsync(long productId, string userId, string title, string content, long? parentId, CancellationToken cancellationToken)
        {
            if (!await _productRepo.TableNoTracking.AnyAsync(s => s.Id == productId))
            {
                throw new Exception("محصول مورد یافت نشد");
            }

            if (parentId != null && !await _commentRepo.TableNoTracking.AnyAsync(s => s.Id == parentId))
            {
                throw new Exception("کامنت والد مورد یافت نشد");
            }

            Comment model = new Comment()
            {
                UserId = userId,
                ProductId = productId,
                Title = title,
                Description = content,
                InsertDate = DateTime.Now
            };

            if (parentId != 0 && parentId != null)
            {
                model.ParentId = parentId;
            }

            await _commentRepo.AddAsync(model, cancellationToken);
        }


        /// <summary>
        /// تعداد نظرات یک محصول
        /// </summary>
        /// <param name="productId">شناسه محصول</param>
        /// <returns></returns>
        public async Task<int> CountCommentsAsync(long productId, CancellationToken cancellationToken)
        {
            return await _commentRepo.TableNoTracking.CountAsync(p => p.ProductId == productId && p.ParentId == null, cancellationToken);

        }


        public async Task<Comment> FindByIdAsync(long commentId, CancellationToken cancellationToken)
        {
            return await _commentRepo.Table.FirstOrDefaultAsync(s => s.Id == commentId, cancellationToken);
        }


        /// <summary>
        /// لیست نظرات یک محصول جهت نمایش
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CommentSelectDto>> GetCommentsAsync(long productId, Pager pager, CancellationToken cancellationToken)
        {
            List<CommentSelectDto> model = await _commentRepo.TableNoTracking
                 .Where(x => x.ProductId == productId && x.ParentId == null)
                 .OrderByDescending(c => c.InsertDate)
                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                 .Take(pager.PageSize)
                  .Select(sx => new CommentSelectDto()
                  {
                      Id = sx.Id,
                      SenderName = sx.User.DisplayName ?? sx.User.UserName ?? "",
                      InsertDate = sx.InsertDate,
                      Title = sx.Title,
                      Content = sx.Description,
                      Like = sx.CommentVote.Count(x => x.Vote == Vote.Like),
                      DisLike = sx.CommentVote.Count(x => x.Vote == Vote.DisLike),
                      UserAvatar = sx.User.Avatar,
                      ReplyCount = sx.Comments.Count
                  }).ToListAsync(cancellationToken);

            DefaultLogo defultpictures = new DefaultLogo();
            if (model.Any(p => p.UserAvatar == null))
            {
                defultpictures = await _defaultLogoRepo.Table.FirstOrDefaultAsync(cancellationToken);
            }

            foreach (CommentSelectDto item in model)
            {
                item.UserAvatar = Url.ResolveServerUrl(_httpContextAccessor, VirtualPathUtility.ToAbsolute(item.UserAvatar ?? defultpictures.UserAvatarUrl ?? Url.DefaultUrl), false);
            }
            return model;
        }



        /// <summary>
        /// جزئیات نظر
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>

        public async Task<CommentDetailDto> GetDetailsAsync(long commentId, CancellationToken cancellationToken)
        {
            CommentDetailDto model = await _commentRepo.TableNoTracking
                .Where(x => x.Id == commentId)
                .Select(sx => new CommentDetailDto()
                {

                    Id = sx.Id,
                    SenderName = sx.User.DisplayName ?? sx.User.UserName ?? "",
                    InsertDate = sx.InsertDate,
                    Title = sx.Title,
                    Content = sx.Description,
                    Like = sx.CommentVote.Count(x => x.Vote == Vote.Like),
                    DisLike = sx.CommentVote.Count(x => x.Vote == Vote.DisLike),
                    UserAvatar = sx.User.Avatar,
                    Replies = sx.Comments.Select(p => new CommentDetailDto.RepliesCommentServiceModel()
                    {
                        Id = p.Id,
                        SenderName = p.User.DisplayName ?? p.User.UserName ?? "",
                        InsertDate = p.InsertDate,
                        Title = p.Title,
                        Content = p.Description,
                        Like = p.CommentVote.Count(x => x.Vote == Vote.Like),
                        DisLike = p.CommentVote.Count(x => x.Vote == Vote.DisLike),
                        UserAvatar = p.User.Avatar
                    }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            DefaultLogo defultpictures = await _defaultLogoRepo.Table.FirstOrDefaultAsync(cancellationToken);

            if (model != null)
            {
                model.UserAvatar = Url.ResolveServerUrl(_httpContextAccessor,
                    VirtualPathUtility
                        .ToAbsolute(model.UserAvatar ?? defultpictures.UserAvatarUrl ?? Url.DefaultUrl), false);

                if (model.Replies != null)
                {
                    foreach (CommentDetailDto.RepliesCommentServiceModel item in model.Replies)
                    {
                        item.UserAvatar = Url.ResolveServerUrl(_httpContextAccessor,
                            VirtualPathUtility
                                .ToAbsolute(item.UserAvatar ?? defultpictures.UserAvatarUrl ?? Url.DefaultUrl), false);
                    }
                }
            }

            return model;
        }



        /// <summary>
        /// ليست کامنت هايي که يک کاربر به کل محصولات داده است
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pager"></param>
        /// <returns></returns>

        public async Task<List<CommentsGetUserCommentProductDto>> GetUserCommentsAsync(string userId, Pager pager, CancellationToken cancellationToken)
        {
            return await _commentRepo.Table.Where(x => x.UserId == userId)
                .OrderByDescending(p => p.InsertDate)
                .Skip((pager.CurrentPage - 1) * pager.PageSize)
                .Take(pager.PageSize)
                .Select(x => new CommentsGetUserCommentProductDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Description,
                    InsertDate = x.InsertDate,
                    Like = x.CommentVote.Count(v => v.Vote == Vote.Like),
                    DisLike = x.CommentVote.Count(v => v.Vote == Vote.DisLike),
                    ProductId = x.ProductId,
                    ProductTitle = x.Product.Title,
                    ReplyCount = x.Comments.Count
                }).ToListAsync(cancellationToken);
        }





        /// <summary>
        /// تعداد نظرات يک کاربر به کل محصولات داده است
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public async Task<int> GetUserCommentsCountAsync(string userId, CancellationToken cancellationToken)
        {
            return await _commentRepo.TableNoTracking.CountAsync(x => x.UserId == userId);
        }

        public async Task LikeOrDisLikeAsync(string userId, long commentId, Vote vote, CancellationToken cancellationToken)
        {
            CommentVote commentVote = await _commontVoteRepo.Table.Where(c => c.CommentId == commentId && c.UserId == userId).FirstOrDefaultAsync();

            if (commentVote == null)
            {
                await _commontVoteRepo.AddAsync(new CommentVote
                {
                    UserId = userId,
                    CommentId = commentId,
                    Vote = vote
                }, cancellationToken);
            }
            else
            {
                commentVote.Vote = vote;
            }

            await _commontVoteRepo.UpdateAsync(commentVote, cancellationToken);
        }



        /// <summary>
        /// جمع تعداد لایک و دیس لایک
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<CommentLikeOrDislikeDto> LikeOrDisLikeResaultAsync(long commentId, CancellationToken cancellationToken)
        {
            return await _commentRepo.TableNoTracking.Where(x => x.Id == commentId)
                .Select(x => new CommentLikeOrDislikeDto
                {
                    Like = x.CommentVote.Count(c => c.Vote == Vote.Like),
                    DisLike = x.CommentVote.Count(c => c.Vote == Vote.DisLike)

                }).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
