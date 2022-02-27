using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedForums.Data.Models;
using RedForums.Data.Services;
using RedForums.Models;

namespace RedForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        [Route("/Post/{title}")]
        public IActionResult Index(string title)
        {
            var post = postsService.GetByTitle<PostViewModel>(title);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpGet]
        [Authorize]
        [Route("/Post/Create/{categoryId}")]
        public IActionResult Create(int categoryId)
        {
            return View(new PostInputModel() { CategoryId = categoryId});
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostInputModel model)
        {
            if (ModelState.IsValid)
            {
                await postsService.CreateAsync(model.Title, model.Content, userManager.GetUserId(User), model.CategoryId);
                return Redirect("/");//TODO: Redirect to post
            }
            return View(model);
        }
    }
}
