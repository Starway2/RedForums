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
        public IActionResult Index(string categoryName)
        {
            var category = categoriesService.GetByName<CategoryViewModel>(categoryName);

            return View(category);
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

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoriesService.DeleteAsync(id);
            return RedirectToPage("/ManageCategories");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Undelete(int id)
        {
            await categoriesService.Undelete(id);
            return RedirectToPage("/ManageCategories");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Update(int id)
        {
            var category = categoriesService.GetAll<CategoryViewModel>().Where(x => x.Id == id).FirstOrDefault();
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = await categoriesService.UpdateAsync(model.Id, model.Name, model.Description);
                //TODO: Redirect to category.
                return Redirect("/");
            }
            return View(model);
        }
    }
}
