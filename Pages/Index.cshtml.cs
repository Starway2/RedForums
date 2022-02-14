using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedForums.Data.Services;
using RedForums.Models;

namespace RedForums.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoriesService categoriesService;

        public ICollection<CategoryViewModel> Categories { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
            this.categoriesService = categoriesService;
            Categories = new HashSet<CategoryViewModel>();
        }

        public void OnGet()
        {
            Categories = categoriesService.GetAll<CategoryViewModel>().ToHashSet();
        }
    }
}