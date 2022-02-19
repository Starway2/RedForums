using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedForums.Data.Services;
using RedForums.Models;

namespace RedForums.Pages
{
    [Authorize(Roles = "Administrator")]
    public class ManageCategoriesModel : PageModel
    {
        private readonly ICategoriesService categoriesService;

        public ICollection<CategoryViewModel> Categories { get; private set; }

        public ManageCategoriesModel(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
            Categories = new HashSet<CategoryViewModel>();
        }
        public void OnGet()
        {
            Categories = categoriesService.GetAll<CategoryViewModel>().ToHashSet();
        }
    }
}
