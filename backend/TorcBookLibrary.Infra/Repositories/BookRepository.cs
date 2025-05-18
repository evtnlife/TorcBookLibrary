using Microsoft.EntityFrameworkCore;
using TorcBookLibrary.Domain.Entities;
using TorcBookLibrary.Domain.Repositories;

namespace TorcBookLibrary.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> SearchAsync(string? author, string? isbn, string? category)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(b => b.FirstName.Contains(author) || b.LastName.Contains(author));
            }

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query = query.Where(b => b.ISBN != null && b.ISBN.Contains(isbn));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(b => b.Category != null && b.Category.Contains(category));
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
