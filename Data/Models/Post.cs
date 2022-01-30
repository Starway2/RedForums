using RedForums.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RedForums.Data.Models
{
    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
