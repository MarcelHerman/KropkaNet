using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjektTurnieju.Pages
{
    public class WylogowanieModel : PageModel
    {
		public async Task<IActionResult> OnGet()
		{
			await HttpContext.SignOutAsync("CookieAuthentication");
			return this.RedirectToPage("/Index");
		}
	}
}
