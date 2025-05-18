using TorcBookLibrary.Services.Dtos;

namespace TorcBookLibrary.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<IEnumerable<BookDto>> SearchAsync(SearchBookDto criteria);
        Task AddAsync(BookDto dto);
        Task UpdateAsync(int id, BookDto dto);
        Task DeleteAsync(int id);
    }
}
