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
    public class CalibrationComplianceSnapshotController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationComplianceSnapshotController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationComplianceSnapshot> Get()
        {
            return _context.Set<CalibrationComplianceSnapshot>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<CalibrationComplianceSnapshot>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationComplianceSnapshot calibrationComplianceSnapshot)
        {
            

            _context.Set<CalibrationComplianceSnapshot>().Add(calibrationComplianceSnapshot);
            await _context.SaveChangesAsync();

            return Created(calibrationComplianceSnapshot);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationComplianceSnapshot calibrationComplianceSnapshot)
        {
            

            if (key != calibrationComplianceSnapshot.CalibrationComplianceSnapshotId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationComplianceSnapshot).State = EntityState.Modified;

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

            return Updated(calibrationComplianceSnapshot);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationComplianceSnapshot> patch)
        {
            
            var entity = await _context.Set<CalibrationComplianceSnapshot>().FindAsync(key);
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
            var entity = await _context.Set<CalibrationComplianceSnapshot>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationComplianceSnapshot>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationComplianceSnapshot>().Count(e => e.CalibrationComplianceSnapshotId == key) > 0;
        }
    }
}