namespace RedForums.Data.Services
{
    public interface ICommentsService : IBaseService
    {
        IEnumerable<T> GetAll<T>(int postId, int? count = null);
    }
}
