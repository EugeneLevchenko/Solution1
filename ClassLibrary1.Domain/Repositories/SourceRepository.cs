using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Domain.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly AuctionDbContext _context;
        public SourceRepository(AuctionDbContext context) => _context = context;
        public async Task<List<Source>> GetAllAsync() => await _context.Sources.ToListAsync();
        public async Task<Source> GetByIdAsync(int id) => await _context.Sources.FirstOrDefaultAsync(s => s.Id == id);
        public async Task UpdateAsync(Source source) => _context.Sources.Update(source);
    }
}
