using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class CalibrationReadingController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationReadingController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationReading> Get()
        {
            return _context.Set<CalibrationReading>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationReading = await _context.Set<CalibrationReading>().FindAsync(key);
            if (calibrationReading == null)
            {
                return NotFound();
            }
            return Ok(calibrationReading);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationReading calibrationReading)
        {
            

            _context.Set<CalibrationReading>().Add(calibrationReading);
            await _context.SaveChangesAsync();

            return Created(calibrationReading);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationReading calibrationReading)
        {
           

            if (key != calibrationReading.CalibrationReadingId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationReading).State = EntityState.Modified;

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

            return Updated(calibrationReading);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationReading> calibrationReading)
        {
           

            var entity = await _context.Set<CalibrationReading>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            calibrationReading.Patch(entity);

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

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var calibrationReading = await _context.Set<CalibrationReading>().FindAsync(key);
            if (calibrationReading == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationReading>().Remove(calibrationReading);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationReading>().Count(e => e.CalibrationReadingId == key) > 0;
        }
    }
}