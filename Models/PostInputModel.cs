using RedForums.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RedForums.Models
{
    public class PostInputModel
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
