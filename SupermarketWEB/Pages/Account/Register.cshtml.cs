using Autenticacion.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacion.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Generar el hash de la contraseña
            using (var sha256 = SHA256.Create())
            {
                User.Password = sha256.ComputeHash(Encoding.UTF8.GetBytes(User.PasswordInput)); 
            }

           

            return RedirectToPage("/Index"); 
        }
    }
}
