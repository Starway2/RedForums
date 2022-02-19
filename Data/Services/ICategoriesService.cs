namespace RedForums.Data.Services
{
    public interface ICategoriesService : IBaseService
    {
        T GetByName<T>(string name);

        Task<string> CreateAsync(string name, string? description);

        Task<string> UpdateAsync(string name, string newName, string? description);
    }
}
