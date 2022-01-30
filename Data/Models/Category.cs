using RedForums.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RedForums.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
