using Autenticacion.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; } = new User();

        private readonly SupermarketContext _dbContext;

        public RegisterModel(SupermarketContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            
            if (await _dbContext.Users.AnyAsync(u => u.Username == User.Username))
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está en uso.");
                return Page();
            }

           
            using (var sha256 = SHA256.Create())
            {
                User.Password = sha256.ComputeHash(Encoding.UTF8.GetBytes(User.PasswordInput));
            }

            
            _dbContext.Users.Add(User);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Index"); 
        }
    }
}
