using ClassLibrary1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface ILotRepository
    {
        Task<Lot> GetByIdAsync(int id);
        Task<List<Lot>> GetByAuctionIdAsync(int auctionId);
        Task DeleteAsync(int id);
    }
}
