using RedForums.Data.Common.Repositories;
using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Data.Services
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> repository;

        public PostsService(IDeletableEntityRepository<Post> repository)
        {
            this.repository = repository;
        }
        public async Task<Post> CreateAsync(string title, string content, string userId, int categoryId)
        {
            var post = new Post() { Title = title, Content = content, CategoryId = categoryId, UserId = userId };
            await repository.AddAsync(post);
            await repository.SaveChangesAsync();
            return post;
        }

        public async Task DeleteAsync(int id)
        {
            var post = repository.All().Where(x => x.Id == id).FirstOrDefault();
            if (post != null)
            {
                repository.Delete(post);
                await repository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Post> query = repository.All().OrderBy(x => x.Title);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id) => repository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

        public T GetByTitle<T>(string title) => repository.All().Where(post => post.Title == title).To<T>().FirstOrDefault();

        public async Task<Post> UpdateAsync(int id, string title, string content, string userId, int categoryId)
        {
            var post = repository.All().Where(x => x.Title == title).FirstOrDefault();

            post.Title = title;
            post.Content = content;
            repository.Update(post);
            await repository.SaveChangesAsync();
            return post;
        }
    }
}
