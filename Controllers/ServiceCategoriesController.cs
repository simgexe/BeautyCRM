using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyCRM.Models;

namespace BeautyCRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCategoriesController : ControllerBase
    {
        private readonly BeautyCrmContext _context;

        public ServiceCategoriesController(BeautyCrmContext context)
        {
            _context = context;
        }

        // GET: api/servicecategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategory>>> GetCategories()
        {
            return await _context.ServiceCategories.ToListAsync();
        }

        // GET: api/servicecategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceCategory>> GetCategory(int id)
        {
            var category = await _context.ServiceCategories.FindAsync(id);
            if (category == null)
                return NotFound();

            return category;
        }

        // POST: api/servicecategories
        [HttpPost]
        public async Task<ActionResult<ServiceCategory>> CreateCategory(ServiceCategory category)
        {
            _context.ServiceCategories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // PUT: api/servicecategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, ServiceCategory category)
        {
            if (id != category.Id)
                return BadRequest();

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ServiceCategories.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/servicecategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.ServiceCategories.FindAsync(id);
            if (category == null)
                return NotFound();

            _context.ServiceCategories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
