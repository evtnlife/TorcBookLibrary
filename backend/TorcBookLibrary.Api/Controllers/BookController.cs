using Microsoft.AspNetCore.Mvc;
using TorcBookLibrary.Services.Dtos;
using TorcBookLibrary.Services.Interfaces;

namespace TorcBookLibrary.Api.Controllers
{
    /// <summary>
    /// Manages book-related operations in the personal library.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves a list of all books in the library.
        /// </summary>
        /// <returns>List of all books</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        /// <summary>
        /// Retrieves a specific book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve</param>
        /// <returns>The requested book if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid book ID.");
            var book = await _service.GetByIdAsync(id);
            return book is null ? NotFound() : Ok(book);
        }

        /// <summary>
        /// Searches books based on author, ISBN, or category.
        /// </summary>
        /// <param name="dto">Search criteria</param>
        /// <returns>List of books matching the criteria</returns>
        [HttpPost("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Search([FromBody] SearchBookDto dto)
        {
            if (dto is null) return BadRequest("Search criteria is required.");
            return Ok(await _service.SearchAsync(dto));
        }

        /// <summary>
        /// Adds a new book to the library.
        /// </summary>
        /// <param name="dto">The book to create</param>
        /// <returns>The created book</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (dto is null) return BadRequest("Book data is required.");
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">The ID of the book to update</param>
        /// <param name="dto">Updated book data</param>
        /// <returns>No content if successful</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto dto)
        {
            if (id <= 0 || dto is null) return BadRequest("Invalid book ID or data.");
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a book from the library.
        /// </summary>
        /// <param name="id">The ID of the book to delete</param>
        /// <returns>No content if successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid book ID.");
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
