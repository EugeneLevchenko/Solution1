using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages.Lots
{
    public class IndexModel : PageModel
    {
        private readonly AuctionDbContext _context;

        public IndexModel(AuctionDbContext context)
        {
            _context = context;
        }

        public List<Lot> Lots { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Lots == null)
            {
                Lots = new List<Lot>();
            }
            else
            {
                Lots = await _context.Lots.ToListAsync();
            }
        }
    }
}
