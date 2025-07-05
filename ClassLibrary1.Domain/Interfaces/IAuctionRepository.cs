using ClassLibrary1.Domain.Entities;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Auction[]> GetAllBySourceIdAsync(int sourceId);
        Task<Auction> GetBySourceIdAsync(int sourceId);
        Task UpdateAsync(Auction auction);
        Task AddAsync(Auction entity);
        Task DeleteBySourceIdAsync(int sourceId, int id, CancellationToken cancellationToken);
    }
}