using RedForums.Data.Common.Repositories;
using RedForums.Data.Mapping;
using RedForums.Data.Models;
using RedForums.Models;

namespace RedForums.Data.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> repository;

        public CommentsService(IDeletableEntityRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<Comment> AddAsync(CommentInputModel model)
        {
            var comment = new Comment() { UserId = model.UserId, Content = model.Content, PostId = model.PostId };
            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteAsync(int id)
        {
            var comment = repository.All().Where(x => x.Id == id).FirstOrDefault();
            if (comment == null) return;
            repository.Delete(comment);
            await repository.SaveChangesAsync();

        }

        public async Task<Comment> EditAsync(CommentInputModel model)
        {
            var comment = repository.All().Where(x => x.Id == model.Id).FirstOrDefault();
            if (comment != null)
            {
                return null;
            }
            comment.Content = model.Content;
            repository.Update(comment);
            await repository.SaveChangesAsync();
            return comment;
        }

        public IEnumerable<T> GetAll<T>(int postId, int? count = null)
        {
            IQueryable<Comment> query = repository.All().OrderByDescending(x => x.CreatedOn);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAll<T>(int? count = null) => repository.AllWithDeleted().To<T>().ToList();

    }
}
