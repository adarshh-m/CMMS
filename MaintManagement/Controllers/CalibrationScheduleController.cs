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
    public class CalibrationScheduleController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationScheduleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationSchedule> Get()
        {
            return _context.Set<CalibrationSchedule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<CalibrationSchedule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationSchedule calibrationSchedule)
        {
            

            _context.Set<CalibrationSchedule>().Add(calibrationSchedule);
            await _context.SaveChangesAsync();

            return Created(calibrationSchedule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationSchedule calibrationSchedule)
        {
            
           
            _context.Entry(calibrationSchedule).State = EntityState.Modified;

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

            return Updated(calibrationSchedule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationSchedule> patch)
        {
           

            var entity = await _context.Set<CalibrationSchedule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<CalibrationSchedule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationSchedule>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationSchedule>().Any(e => e.CalibrationScheduleId == key);
        }
    }
}