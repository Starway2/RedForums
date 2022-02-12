using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedForums.Pages
{
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Administrator"))
                {
                    return Page();
                }
                return Redirect("/");
            }
            return Redirect("/");
        }
    }
}
