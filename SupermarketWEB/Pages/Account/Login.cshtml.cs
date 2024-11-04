using Autenticacion.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (User.Username == "correo@gmail.com" && User.Password == "12345")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            return Page();
        }
    }
}
