using System.ComponentModel.DataAnnotations;

namespace RedForums.Models
{
    public class CategoryInputModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
