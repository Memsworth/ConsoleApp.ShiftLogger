using BusinessLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Models;
using DataAccessLayer;

namespace ShiftLoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ShiftLoggerDbContext _context;

        public EmployeeController(ShiftLoggerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestEmployeeDto>>> GetEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }

          return await _context.Employees
              .Select(x => new RequestEmployeeDto(x))
              .ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestEmployeeDto>> GetEmployee(int id)
        {
            
            var employee = await _context.Employees.FindAsync(id);

          if (employee == null)
          {
              return NotFound();
          }

          return new RequestEmployeeDto(employee);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestEmployeeDto>> PostEmployee(RequestEmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                DateOfBirth = employeeDto.DateOfBirth,
                Email = employeeDto.Email
            };
          if (_context.Employees == null)
          {
              return Problem("Entity set 'ShiftLoggerDbContext.Employees'  is null.");
          }
          _context.Employees.Add(employee);
          await _context.SaveChangesAsync();
          return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employeeDto);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
