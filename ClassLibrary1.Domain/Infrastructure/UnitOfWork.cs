using ClassLibrary1.Domain.Data;
using ClassLibrary1.Domain.Interfaces;
using ClassLibrary1.Domain.Repositories;

namespace ClassLibrary1.Domain.Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly AuctionDbContext _context;

    private ISourceRepository? _sources;
    private IAuctionRepository? _auctions;
    private ILotRepository? _lots;
    private bool _disposed;

    public ISourceRepository Sources => _sources ??= new SourceRepository(_context);
    public IAuctionRepository Auctions => _auctions ??= new AuctionRepository(_context);
    public ILotRepository Lots => _lots ??= new LotRepository(_context);

    public UnitOfWork(AuctionDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

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

    public Task<int> UpdateTitleByIdAsync(int id, string newTitle, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}