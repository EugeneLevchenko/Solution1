using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Domain.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _context;
        public AuctionRepository(AuctionDbContext context) => _context = context;

        public async Task<Auction[]> GetAllBySourceIdAsync(int sourceId)
        {
            return await _context.Auctions
                .Where(a => a.SourceId == sourceId)
                .ToArrayAsync();
        }

        public async Task<Auction> GetBySourceIdAsync(int sourceId) => await _context.Auctions.FirstOrDefaultAsync(a => a.SourceId == sourceId);

        public async Task DeleteBySourceIdAsync(int sourceId, int id, CancellationToken cancellationToken)
        {
            await _context.Auctions
                .Where(a => a.SourceId == sourceId && a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public async Task<int> UpdateNameBySourceIdAsync(int sourceId, string name, CancellationToken cancellationToken)
        {
            return await _context.Auctions
                .Where(a => a.SourceId == sourceId)
                .ExecuteUpdateAsync(a => a.SetProperty(b => b.Name, name), cancellationToken);
        }
    }
}
