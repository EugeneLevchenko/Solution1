using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly AuctionDbContext _context;
        public LotRepository(AuctionDbContext context) => _context = context;

        public async Task<Lot> GetByIdAsync(int id) => await _context.Lots.FindAsync(id);
        public async Task<List<Lot>> GetByAuctionIdAsync(int auctionId) =>
            await _context.Lots.Where(l => l.AuctionId == auctionId).ToListAsync();
        public async Task DeleteAsync(int id)
        {
            var lot = await _context.Lots.FindAsync(id);
            if (lot != null) _context.Lots.Remove(lot);
        }
    }
}
