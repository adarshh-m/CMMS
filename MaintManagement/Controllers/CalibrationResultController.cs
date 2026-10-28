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
    public class CalibrationResultController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationResultController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var calibrationResults = await _context.Set<CalibrationResult>().ToListAsync();
            return Ok(calibrationResults);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationResult = await _context.Set<CalibrationResult>().FindAsync(key);
            if (calibrationResult == null)
            {
                return NotFound();
            }
            return Ok(calibrationResult);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationResult calibrationResult)
        {
            
            _context.Set<CalibrationResult>().Add(calibrationResult);
            await _context.SaveChangesAsync();

            return Created(calibrationResult);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationResult calibrationResult)
        {
           
            if (key != calibrationResult.CalibrationResultId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationResult).State = EntityState.Modified;

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

            return Updated(calibrationResult);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationResult> calibrationResult)
        {
            
            var entity = await _context.Set<CalibrationResult>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            calibrationResult.Patch(entity);

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
            var calibrationResult = await _context.Set<CalibrationResult>().FindAsync(key);
            if (calibrationResult == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationResult>().Remove(calibrationResult);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationResult>().Any(e => e.CalibrationResultId == key);
        }
    }
}