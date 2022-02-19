using RedForums.Data.Common.Repositories;
using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Data.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query = categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name) => categoriesRepository.All().Where(x => x.Name == name).To<T>().FirstOrDefault();

        public async Task<string> CreateAsync(string name, string? description)
        {
            var category = new Category() { Name = name, Description = description };
            await categoriesRepository.AddAsync(category);
            await categoriesRepository.SaveChangesAsync();
            return category.Name;
        }

        public async Task DeleteAsync(int id)
        {
            var category = categoriesRepository.All().Where(x => x.Id == id).FirstOrDefault();
            if (category != null)
            {
                categoriesRepository.Delete(category);
                await categoriesRepository.SaveChangesAsync();
            }
        }

        public async Task<string> UpdateAsync(string name, string newName, string? description)
        {
            var category = categoriesRepository.All().Where(x => x.Name != newName).FirstOrDefault();
            
            category.Name = newName;
            category.Description = description;
            categoriesRepository.Update(category);
            await categoriesRepository.SaveChangesAsync();
            return category.Name;
        }
    }
}
