using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class CalibrationMethodController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationMethodController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationMethod> Get()
        {
            return _context.Set<CalibrationMethod>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationMethod = await _context.Set<CalibrationMethod>().FindAsync(key);
            if (calibrationMethod == null)
            {
                return NotFound();
            }
            return Ok(calibrationMethod);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationMethod calibrationMethod)
        {
            
            _context.Set<CalibrationMethod>().Add(calibrationMethod);
            await _context.SaveChangesAsync();
            return Created(calibrationMethod);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] CalibrationMethod update)
        {
            
            if (key != update.CalibrationMethodId)
            {
                return BadRequest();
            }
            _context.Entry(update).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationMethod> patch)
        {
            
            var calibrationMethod = await _context.Set<CalibrationMethod>().FindAsync(key);
            if (calibrationMethod == null)
            {
                return NotFound();
            }
            patch.Patch(calibrationMethod);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(calibrationMethod);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var calibrationMethod = await _context.Set<CalibrationMethod>().FindAsync(key);
            if (calibrationMethod == null)
            {
                return NotFound();
            }
            _context.Set<CalibrationMethod>().Remove(calibrationMethod);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationMethod>().Find(key) != null;
        }
    }
}