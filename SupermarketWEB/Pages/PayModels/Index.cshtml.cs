using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketWEB.Pages.PayModels
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<PayMode> PayModels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PayModel != null)
            {
                PayModels = await _context.PayModel.ToListAsync();
            }
        }
    }
}
