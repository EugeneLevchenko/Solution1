using ClassLibrary1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface IAuctionRepository
    {
        Task<List<Auction>> GetBySourceIdAsync(int sourceId);
        Task<Auction> GetByIdAsync(int id);
        Task UpdateAsync(Auction auction);
        Task DeleteAsync(int id);
        Task<List<Auction>> GetAllBySourceIdAsync(int sourceId);
        Task AddAsync(Auction entity);
        void Remove(Auction entity);
        Task<List<Auction>> GetAllAsync();
    }
}
