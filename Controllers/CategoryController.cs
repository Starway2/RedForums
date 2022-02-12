using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedForums.Data.Services;
using RedForums.Models;

namespace RedForums.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            var categories = categoriesService.GetAll<CategoryViewModel>().ToList();

            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(CategoryInputModel model)
        {
            if (ModelState.IsValid)
            {
                string category = await categoriesService.CreateAsync(model.Name, model.Description);
                //TODO: redirect to category
                return Redirect("/");
            }
            return View(model);
        }
    }
}
