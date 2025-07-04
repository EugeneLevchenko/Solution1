﻿using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Entities;
using ClassLibrary1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Domain.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly AuctionDbContext _context;
        public SourceRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Source>> GetAllAsync()
        {
            return await _context.Sources.ToListAsync();
        }

        public async Task<Source> GetByIdAsync(int id)
        {
            return await _context.Sources.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Source source)
        {
            _context.Sources.Update(source);
        }

        public async Task<int> UpdateTitleByIdAsync(int id, string newTitle, CancellationToken cancellationToken)
        {
            return await _context.Sources
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(t => t.Title, newTitle), cancellationToken);
        }
    }
}