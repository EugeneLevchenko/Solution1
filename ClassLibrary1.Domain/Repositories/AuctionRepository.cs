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

        public async Task<Auction> GetBySourceIdAsync(int sourceId) => await _context.Auctions.FindAsync(sourceId);

        public async Task UpdateAsync(Auction auction)
        {
            await _context.Auctions
                .Where(a => a.SourceId == auction.SourceId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(a => a.Name, auction.Name)
                    .SetProperty(a => a.Status, auction.Status));
        }

        public async Task AddAsync(Auction entity)
        {
            await _context.Auctions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBySourceIdAsync(int sourceId, int id, CancellationToken cancellationToken)
        {
            await _context.Auctions
                .Where(a => a.SourceId == sourceId && a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
