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

        public async Task<List<Auction>> GetBySourceIdAsync(int sourceId) =>
            await _context.Auctions.Where(a => a.SourceId == sourceId).ToListAsync();
        public async Task<Auction> GetByIdAsync(int id) => await _context.Auctions.FindAsync(id);
        public async Task UpdateAsync(Auction auction) => _context.Auctions.Update(auction);
        public async Task DeleteAsync(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction != null) _context.Auctions.Remove(auction);
        }

        public async Task<List<Auction>> GetAllBySourceIdAsync(int sourceId)
        {
            return await _context.Auctions
                .Where(a => a.SourceId == sourceId)
                .ToListAsync();
        }

        public async Task AddAsync(Auction entity)
        {
            await _context.Auctions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Remove(Auction entity)
        {
            _context.Auctions.Remove(entity);
        }
        public async Task<List<Auction>> GetAllAsync()
        {
            return await _context.Auctions.ToListAsync();
        }

        public async Task DeleteByIdAsync(int sourceId, int id, CancellationToken cancellationToken)
        {
            await _context.Auctions
                .Where(a => a.SourceId == sourceId && a.Id == id)
                .ExecuteDeleteAsync(cancellationToken);
        }
    }
}
