namespace RedForums.Data.Services
{
    public interface IBaseService
    {
        IEnumerable<T> GetAll<T>(int? count = null);
        Task DeleteAsync(int id);
    }
}
