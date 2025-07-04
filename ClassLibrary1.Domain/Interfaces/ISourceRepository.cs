using ClassLibrary1.Domain.Entities;

namespace ClassLibrary1.Domain.Interfaces
{
    public interface ISourceRepository
    {
        Task<List<Source>> GetAllAsync();
        Task<Source> GetByIdAsync(int id);
        Task UpdateAsync(Source source);
    }
}
