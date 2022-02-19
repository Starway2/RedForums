namespace RedForums.Data.Services
{
    public interface IPostsService : IBaseService
    {
        T GetByTitle<T>(string title);

        Task<int> CreateAsync(string title, string content, string userId, int categoryId);

        Task<int> UpdateAsync(int id, string title, string content, string userId, int categoryId);
    }
}
