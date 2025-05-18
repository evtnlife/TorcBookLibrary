using TorcBookLibrary.Domain.Entities;
using TorcBookLibrary.Domain.Repositories;
using TorcBookLibrary.Services.Dtos;
using TorcBookLibrary.Services.Interfaces;

namespace TorcBookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _repo.GetAllAsync();
            return books.Select(MapToDto);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            return book is null ? null : MapToDto(book);
        }

        public async Task<IEnumerable<BookDto>> SearchAsync(SearchBookDto criteria)
        {
            var results = await _repo.SearchAsync(criteria.Author, criteria.ISBN, criteria.Category);
            return results.Select(MapToDto);
        }

        public async Task AddAsync(BookDto dto)
        {
            var book = MapToEntity(dto);
            await _repo.AddAsync(book);
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, BookDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new Exception("Book not found");

            existing.Title = dto.Title;
            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.TotalCopies = dto.TotalCopies;
            existing.CopiesInUse = dto.CopiesInUse;
            existing.Type = dto.Type;
            existing.ISBN = dto.ISBN;
            existing.Category = dto.Category;

            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) throw new Exception("Book not found");

            await _repo.DeleteAsync(book);
            await _repo.SaveChangesAsync();
        }

        private static BookDto MapToDto(Book b) => new()
        {
            Id = b.BookId,
            Title = b.Title,
            FirstName = b.FirstName,
            LastName = b.LastName,
            TotalCopies = b.TotalCopies,
            CopiesInUse = b.CopiesInUse,
            Type = b.Type,
            ISBN = b.ISBN,
            Category = b.Category
        };

        private static Book MapToEntity(BookDto dto) => new()
        {
            BookId = dto.Id,
            Title = dto.Title,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            TotalCopies = dto.TotalCopies,
            CopiesInUse = dto.CopiesInUse,
            Type = dto.Type,
            ISBN = dto.ISBN,
            Category = dto.Category
        };
    }
}
