
namespace ClassLibrary1.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISourceRepository Sources { get; }
        IAuctionRepository Auctions { get; }
        ILotRepository Lots { get; }
    }
}
