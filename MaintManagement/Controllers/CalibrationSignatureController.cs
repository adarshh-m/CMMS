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
    public class CalibrationSignatureController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationSignatureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationSignature> Get()
        {
            return _context.Set<CalibrationSignature>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationSignature = await _context.Set<CalibrationSignature>().FindAsync(key);
            if (calibrationSignature == null)
            {
                return NotFound();
            }
            return Ok(calibrationSignature);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationSignature calibrationSignature)
        {
           

            _context.Set<CalibrationSignature>().Add(calibrationSignature);
            await _context.SaveChangesAsync();

            return Created(calibrationSignature);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationSignature calibrationSignature)
        {
           

            if (key != calibrationSignature.CalibrationSignatureId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationSignature).State = EntityState.Modified;

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

            return Updated(calibrationSignature);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationSignature> calibrationSignature)
        {
            

            var entity = await _context.Set<CalibrationSignature>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            calibrationSignature.Patch(entity);

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
            var calibrationSignature = await _context.Set<CalibrationSignature>().FindAsync(key);
            if (calibrationSignature == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationSignature>().Remove(calibrationSignature);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationSignature>().Count(e => e.CalibrationSignatureId == key) > 0;
        }
    }
}