using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Interfaces;
using ClassLibrary1.Domain.Repositories;

namespace ClassLibrary1.Domain.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionDbContext _context;

    private ISourceRepository? _sources;
    private bool _disposed;

    public ISourceRepository Sources => _sources ??= new SourceRepository(_context);

    public IAuctionRepository Auctions { get; }
    public ILotRepository Lots { get; }

    public UnitOfWork(AuctionDbContext context)
    {
        _context = context;
        Auctions = new AuctionRepository(context);
        Lots = new LotRepository(context);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}