using TorcBookLibrary.Domain.Entities;

namespace TorcBookLibrary.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, string? category);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveChangesAsync();
    }
}
