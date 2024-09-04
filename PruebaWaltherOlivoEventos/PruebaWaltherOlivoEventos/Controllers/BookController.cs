//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PruebaWaltherOlivoEventos.Context;
//using PruebaWaltherOlivoEventos.Dtos;
//using PruebaWaltherOlivoEventos.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PruebaWaltherOlivoEventos.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BookController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public BookController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Book
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
//        {
//            return await _context.Book.Include(b => b.Category).ToListAsync();
//        }

//        // GET: api/Book/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Book>> GetBookById(int id)
//        {
//            var book = await _context.Book.Include(b => b.Category).FirstOrDefaultAsync(b => b.BookId == id);

//            if (book == null)
//            {
//                return NotFound();
//            }

//            return book;
//        }

//        [HttpPost]
//        public async Task<ActionResult<Book>> CreateBook([FromBody] BookDto bookDto)
//        {
//            if (string.IsNullOrWhiteSpace(bookDto.Title))
//            {
//                return BadRequest("El título del libro no puede estar vacío.");
//            }

//            if (bookDto.Category == null || bookDto.Category.CategoryId <= 0)
//            {
//                return BadRequest("Debe proporcionar un ID de categoría válido.");
//            }

//            var category = await _context.Category.FindAsync(bookDto.Category.CategoryId);
//            if (category == null)
//            {
//                return BadRequest("La categoría especificada no existe.");
//            }

//            var book = new Book
//            {
//                Title = bookDto.Title,
//                CategoryId = bookDto.Category.CategoryId,
//                Category = category
//            };

//            _context.Book.Add(book);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
//        }

//        // PUT: api/Book/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto bookDto)
//        {
//            if (string.IsNullOrWhiteSpace(bookDto.Title))
//            {
//                return BadRequest("El título del libro no puede estar vacío.");
//            }

//            if (bookDto.Category == null || bookDto.Category.CategoryId <= 0)
//            {
//                return BadRequest("Debe proporcionar un ID de categoría válido.");
//            }

//            var category = await _context.Category.FindAsync(bookDto.Category.CategoryId);
//            if (category == null)
//            {
//                return BadRequest("La categoría especificada no existe.");
//            }

//            var existingBook = await _context.Book.FindAsync(id);
//            if (existingBook == null)
//            {
//                return NotFound();
//            }

//            // Actualizar los campos del libro
//            existingBook.Title = bookDto.Title;
//            existingBook.CategoryId = bookDto.Category.CategoryId;
//            existingBook.Category = category;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                return StatusCode(500, "Error al actualizar el libro.");
//            }

//            return NoContent();
//        }

//        // DELETE: api/Book/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteBook(int id)
//        {
//            var book = await _context.Book.FindAsync(id);
//            if (book == null)
//            {
//                return NotFound();
//            }

//            _context.Book.Remove(book);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }
//}
