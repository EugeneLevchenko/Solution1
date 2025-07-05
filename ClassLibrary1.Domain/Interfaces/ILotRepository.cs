using ClassLibrary1.Domain.Entities;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface ILotRepository
    {
        Task<Lot> GetByIdAsync(int id);
        Task<List<Lot>> GetByAuctionIdAsync(int auctionId);
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
