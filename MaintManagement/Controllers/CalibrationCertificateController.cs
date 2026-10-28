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
    public class CalibrationCertificateController : ODataController
    {
        private readonly CmmsContext _context;

        public CalibrationCertificateController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<CalibrationCertificate> Get()
        {
            return _context.Set<CalibrationCertificate>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var calibrationCertificate = await _context.Set<CalibrationCertificate>().FindAsync(key);
            if (calibrationCertificate == null)
            {
                return NotFound();
            }
            return Ok(calibrationCertificate);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationCertificate calibrationCertificate)
        {
            

            _context.Set<CalibrationCertificate>().Add(calibrationCertificate);
            await _context.SaveChangesAsync();

            return Created(calibrationCertificate);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationCertificate calibrationCertificate)
        {
            

            if (key != calibrationCertificate.CalibrationCertificateId)
            {
                return BadRequest();
            }

            _context.Entry(calibrationCertificate).State = EntityState.Modified;

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

            return Updated(calibrationCertificate);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationCertificate> patch)
        {
            

            var calibrationCertificate = await _context.Set<CalibrationCertificate>().FindAsync(key);
            if (calibrationCertificate == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationCertificate);

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

            return Updated(calibrationCertificate);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var calibrationCertificate = await _context.Set<CalibrationCertificate>().FindAsync(key);
            if (calibrationCertificate == null)
            {
                return NotFound();
            }

            _context.Set<CalibrationCertificate>().Remove(calibrationCertificate);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<CalibrationCertificate>().Any(e => e.CalibrationCertificateId == key);
        }
    }
}