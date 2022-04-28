using AutoMapper;
using FastShop.DataAccess;
using FastShop.Dtos.Requests;
using FastShop.Dtos.Responses;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Business
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            this.commentRepository = commentRepository;
            this.mapper = mapper;
        }

        public async Task AddComment(AddCommentRequest request)
        {
            var comment = mapper.Map<Comment>(request);
            await commentRepository.Add(comment);
        }

        public async Task DeleteComment(int id)
        {
            await commentRepository.Delete(id);
        }

        public async Task<IList<CommentListResponse>> GetAllComments()
        {
            var comments = await commentRepository.GetAllEntites();
            var commentListResponse = mapper.Map<List<CommentListResponse>>(comments);
            return commentListResponse;
        }

        public int GetCommentCountByProduct(int id)
        {
            var commentCount = commentRepository.GetCommentCounts(id);
            return commentCount;
        }

        public IList<CommentListResponse> GetComments(int id)
        {
            var comment = commentRepository.GetCommentByProductId(id);

            var commentListResponse = mapper.Map<IList<CommentListResponse>>(comment);
            return commentListResponse;

        }

        public async Task<bool> IsExist(int id)
        {
            return await commentRepository.IsExists(id);
        }
    }
}
