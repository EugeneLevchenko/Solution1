using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISourceRepository Sources { get; }
        IAuctionRepository Auctions { get; }
        ILotRepository Lots { get; }
        Task<int> SaveChangesAsync();
    }
}
