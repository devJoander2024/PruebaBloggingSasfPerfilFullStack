//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PruebaWaltherOlivoEventos.Context;
//using PruebaWaltherOlivoEventos.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PruebaWaltherOlivoEventos.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public CategoryController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Category
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
//        {
//            return await _context.Category.ToListAsync();
//        }

//        // GET: api/Category/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Category>> GetCategoryById(int id)
//        {
//            var category = await _context.Category.FindAsync(id);

//            if (category == null)
//            {
//                return NotFound();
//            }

//            return category;
//        }

//        // POST: api/Category
//        [HttpPost]
//        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
//        {
//            if (string.IsNullOrWhiteSpace(category.Name))
//            {
//                return BadRequest("El nombre de la categoría no puede estar vacío.");
//            }

//            _context.Category.Add(category);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CategoryId }, category);
//        }

//        // PUT: api/Category/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
//        {
//            if (id != category.CategoryId)
//            {
//                return NotFound("");
//            }

//            var existingCategory = await GetCategoryById(id);
//            if (existingCategory.Result is NotFoundResult)
//            {
//                return NotFound();
//            }

//            if (string.IsNullOrWhiteSpace(category.Name))
//            {
//                return BadRequest("El nombre de la categoría no puede estar vacío.");
//            }

//            _context.Entry(category).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (existingCategory == null)
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // DELETE: api/Category/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCategory(int id)
//        {
//            var category = await _context.Category.FindAsync(id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            _context.Category.Remove(category);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//    }
//}
