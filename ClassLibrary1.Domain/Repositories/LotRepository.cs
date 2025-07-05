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

        public async Task<Lot> GetBySourceAndAuctionIdAsync(int sourceId, int auctionId, CancellationToken cancellationToken)
        {
            return await _context.Lots
         .Where(a => a.SourceId == sourceId && a.AuctionId == auctionId)
         .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Lot>> GetByAuctionIdAsync(int auctionId)
        {
            return await _context.Lots.Where(l => l.AuctionId == auctionId).ToListAsync();
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _context.Lots
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
