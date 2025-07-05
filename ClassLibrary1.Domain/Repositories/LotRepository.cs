using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Domain.Repositories
{
    public class LotRepository : ILotRepository
    {
        private readonly AuctionDbContext _context;
        public LotRepository(AuctionDbContext context) => _context = context;
        public async Task<Lot> GetByIdAsync(int id) => await _context.Lots.FirstOrDefaultAsync(l => l.Id == id);
        public async Task<List<Lot>> GetByAuctionIdAsync(int auctionId) =>
            await _context.Lots.Where(l => l.AuctionId == auctionId).ToListAsync();
        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _context.Lots
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
