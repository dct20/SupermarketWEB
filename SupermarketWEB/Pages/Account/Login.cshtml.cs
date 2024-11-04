using Autenticacion.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using System.Collections.Generic; // Asegúrate de tener esto importado para usar List
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();

        private readonly SupermarketContext _dbContext;

        public LoginModel(SupermarketContext dbContext) // Inyección de dependencias para el DbContext
        {
            _dbContext = dbContext;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Buscar el usuario en la base de datos
            var storedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == User.Username);
            if (storedUser == null)
            {
                ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                return Page();
            }

            // Generar el hash de la contraseña ingresada
            using (var sha256 = SHA256.Create())
            {
                var passwordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(User.PasswordInput));

                // Comparar los hashes
                if (!passwordHash.SequenceEqual(storedUser.Password))
                {
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                    return Page();
                }
            }

            // Autenticación exitosa
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, storedUser.Username),
                // Puedes agregar otros claims si es necesario
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            return RedirectToPage("/Index"); // Redirigir a la página principal
        }
    }
}
