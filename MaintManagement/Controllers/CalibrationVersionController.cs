using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class CalibrationVersionController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationVersionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationVersion> Get()
        {
            return _context.Set<CalibrationVersion>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationVersion = await _context.Set<CalibrationVersion>().FindAsync(key);
            if (calibrationVersion == null)
            {
                return NotFound();
            }
            return Ok(calibrationVersion);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationVersion calibrationVersion)
        {
            
            _context.Set<CalibrationVersion>().Add(calibrationVersion);
            await _context.SaveChangesAsync();

            return Created(calibrationVersion);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationVersion calibrationVersion)
        {
           

            if (key != calibrationVersion.CalibrationVersionId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationVersion).State = EntityState.Modified;

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

            return Updated(calibrationVersion);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationVersion> patch)
        {
            

            var calibrationVersion = await _context.Set<CalibrationVersion>().FindAsync(key);
            if (calibrationVersion == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationVersion);

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

            return Updated(calibrationVersion);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var calibrationVersion = await _context.Set<CalibrationVersion>().FindAsync(key);
            if (calibrationVersion == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationVersion>().Remove(calibrationVersion);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationVersion>().Count(e => e.CalibrationVersionId == key) > 0;
        }
    }

   
}