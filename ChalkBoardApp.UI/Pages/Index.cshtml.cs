using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ChalkBoardApp.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty, Required]
        public string Username { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Anropa signInManager för att logga in användaren
            //PasswordSignIn kollar användare + lösenord, och skapar en cookie
            var result = await _signInManager.PasswordSignInAsync(Username, Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(Username);
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return RedirectToPage("");
                }
                return RedirectToPage("");
            }

            return Page();
        }
    }
}
