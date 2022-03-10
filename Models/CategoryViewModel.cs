using RedForums.Data.Mapping;
using RedForums.Data.Models;

namespace RedForums.Models
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int PostsCount { get; set; } 

        public bool IsDeleted { get; set; }

        public IEnumerable<PostViewModel>? Posts { get; set; }
    }
}
