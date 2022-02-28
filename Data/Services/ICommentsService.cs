using RedForums.Data.Models;
using RedForums.Models;

namespace RedForums.Data.Services
{
    public interface ICommentsService : IBaseService
    {
        IEnumerable<T> GetAll<T>(int postId, int? count = null);

        Task<Comment> AddAsync(CommentInputModel model);

        Task<Comment> EditAsync(CommentInputModel model);
    }
}
