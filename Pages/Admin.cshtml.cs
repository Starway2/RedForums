using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedForums.Pages
{
    [Authorize(Roles = "Administrator")]
    public class AdminModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
