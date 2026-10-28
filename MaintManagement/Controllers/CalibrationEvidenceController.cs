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
    public class CalibrationEvidenceController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationEvidenceController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationEvidence> Get()
        {
            return _context.Set<CalibrationEvidence>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationEvidence = await _context.Set<CalibrationEvidence>().FindAsync(key);
            if (calibrationEvidence == null)
            {
                return NotFound();
            }
            return Ok(calibrationEvidence);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationEvidence calibrationEvidence)
        {
            

            _context.Set<CalibrationEvidence>().Add(calibrationEvidence);
            await _context.SaveChangesAsync();

            return Created(calibrationEvidence);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationEvidence calibrationEvidence)
        {
            

            if (key != calibrationEvidence.CalibrationEvidenceId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationEvidence).State = EntityState.Modified;

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

            return Updated(calibrationEvidence);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationEvidence> patch)
        {
            

            var calibrationEvidence = await _context.Set<CalibrationEvidence>().FindAsync(key);
            if (calibrationEvidence == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationEvidence);

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

            return Updated(calibrationEvidence);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var calibrationEvidence = await _context.Set<CalibrationEvidence>().FindAsync(key);
            if (calibrationEvidence == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationEvidence>().Remove(calibrationEvidence);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationEvidence>().Count(e => e.CalibrationEvidenceId == key) > 0;
        }
    }
}