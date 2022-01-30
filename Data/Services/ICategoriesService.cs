namespace RedForums.Data.Services
{
    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        Task<string> CreateAsync(string name, string? description);

        Task DeleteAsync(string name);

        Task<string> UpdateAsync(string name, string newName, string? description);
    }
}
