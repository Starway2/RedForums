using RedForums.Data.Models;

namespace RedForums.Data.Services
{
    public interface IPostsService : IBaseService
    {
        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task<Post> CreateAsync(string title, string content, string userId, int categoryId);

        Task<Post> UpdateAsync(int id, string title, string content, string userId, int categoryId);
    }
}
