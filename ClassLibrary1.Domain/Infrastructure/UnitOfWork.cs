using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Interfaces;
using ClassLibrary1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionDbContext _context;
    public ISourceRepository Sources { get; }
    public IAuctionRepository Auctions { get; }
    public ILotRepository Lots { get; }

    public UnitOfWork(AuctionDbContext context)
    {
        _context = context;
        Sources = new SourceRepository(context);
        Auctions = new AuctionRepository(context);
        Lots = new LotRepository(context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}