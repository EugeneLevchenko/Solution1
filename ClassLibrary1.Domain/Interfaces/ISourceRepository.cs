using ClassLibrary1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface ISourceRepository
    {
        Task<List<Source>> GetAllAsync();
        Task<Source> GetByIdAsync(int id);
        Task UpdateAsync(Source source);
    }
}
