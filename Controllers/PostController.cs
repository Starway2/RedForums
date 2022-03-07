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
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostsService postsService, ICommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = postsService.GetById<PostViewModel>(id);
            if (post == null) return NotFound();
            post.Comments = commentsService.GetAll<CommentViewModel>(post.Id).OrderBy(x => x.CreatedOn);

            return View(post);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int categoryId)
        {
            return View(new PostInputModel() { CategoryId = categoryId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostInputModel model)
        {
            if (ModelState.IsValid)
            {
                var post = await postsService.CreateAsync(model.Title, model.Content, userManager.GetUserId(User), model.CategoryId);
                if (post == null) return NotFound();
                return RedirectToAction("Index", "Post", new { area = "", id = post.Id });
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CommentInputModel model)
        {
            var post = postsService.GetById<PostViewModel>(model.PostId);
            if (post == null) return BadRequest();

            if (ModelState.IsValid)
            {
                await commentsService.AddAsync(model);
            }
            return RedirectToAction("Index", "Post", new { area = "", id = post.Id });
        }
    }
}
