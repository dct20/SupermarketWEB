using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;

        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Category) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Products == null || Product == null)
            {
                return NotFound();
            }

            var productToDelete = await _context.Products.FindAsync(Product.Id);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
