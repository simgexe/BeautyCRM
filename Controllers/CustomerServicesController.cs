using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyCRM.Models;

namespace BeautyCRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerServicesController : ControllerBase
    {
        private readonly BeautyCrmContext _context;

        public CustomerServicesController(BeautyCrmContext context)
        {
            _context = context;
        }

        // GET: api/customerservices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerService>>> GetCustomerServices()
        {
            return await _context.CustomerServices
                .Include(cs => cs.Customer)
                .Include(cs => cs.Service)
                .ToListAsync();
        }

        // GET: api/customerservices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerService>> GetCustomerService(int id)
        {
            var record = await _context.CustomerServices
                .Include(cs => cs.Customer)
                .Include(cs => cs.Service)
                .FirstOrDefaultAsync(cs => cs.Id == id);

            if (record == null)
                return NotFound();

            return record;
        }

        // POST: api/customerservices
        [HttpPost]
        public async Task<ActionResult<CustomerService>> CreateCustomerService(CustomerService cs)
        {
            _context.CustomerServices.Add(cs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerService), new { id = cs.Id }, cs);
        }

        // PUT: api/customerservices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerService(int id, CustomerService cs)
        {
            if (id != cs.Id)
                return BadRequest();

            _context.Entry(cs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CustomerServices.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/customerservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerService(int id)
        {
            var cs = await _context.CustomerServices.FindAsync(id);
            if (cs == null)
                return NotFound();

            _context.CustomerServices.Remove(cs);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
