using Microsoft.AspNetCore.Mvc;

namespace RedForums.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
