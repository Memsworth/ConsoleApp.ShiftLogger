using BusinessLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Models;
using DataAccessLayer;

namespace ShiftLoggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly ShiftLoggerDbContext _context;

        public ShiftController(ShiftLoggerDbContext context)
        {
            _context = context;
        }

        // GET: api/Shift
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestShiftDto>>> GetShifts()
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }

          return await _context.Shifts.Select(x => ShiftDto(x)).ToListAsync();
        }

        // GET: api/Shift/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestShiftDto>> GetShift(int id)
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
          var shift = await _context.Shifts.FindAsync(id);

          if (shift == null)
          {
              return NotFound();
          }

          return ShiftDto(shift);
        }

        // PUT: api/Shift/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(int id, Shift shift)
        {
            if (id != shift.ShiftId)
            {
                return BadRequest();
            }

            _context.Entry(shift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(id))
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

        // POST: api/Shift
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestShiftDto>> PostShift(RequestShiftDto shiftDto)
        {
            var shift = new Shift
            {
                StartTime = shiftDto.StartTime,
                EndTime = shiftDto.EndTime,
                EmployeeId = shiftDto.EmployeeId
            };
          if (_context.Shifts == null)
          {
              return Problem("Entity set 'ShiftLoggerDbContext.Shifts'  is null.");
          }
          _context.Shifts.Add(shift);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetShift", new { id = shift.ShiftId }, ShiftDto(shift));
        }

        // DELETE: api/Shift/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            if (_context.Shifts == null)
            {
                return NotFound();
            }
            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null)
            {
                return NotFound();
            }

            _context.Shifts.Remove(shift);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShiftExists(int id)
        {
            return (_context.Shifts?.Any(e => e.ShiftId == id)).GetValueOrDefault();
        }

        private static RequestShiftDto ShiftDto(Shift shift) => new()
        {
            ShiftId = shift.ShiftId,
            StartTime = shift.StartTime,
            EndTime = shift.EndTime,
            EmployeeId = shift.EmployeeId,
        };
    }
}
