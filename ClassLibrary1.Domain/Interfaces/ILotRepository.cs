using ClassLibrary1.Domain.Entities;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface ILotRepository
    {
        Task<Lot> GetBySourceAndAuctionIdAsync(int sourceId, int auctionId, CancellationToken cancellationToken);
        Task<List<Lot>> GetByAuctionIdAsync(int auctionId);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
