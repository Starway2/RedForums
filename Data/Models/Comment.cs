using RedForums.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace RedForums.Data.Models
{
    public  class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}