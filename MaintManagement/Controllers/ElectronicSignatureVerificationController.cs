using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureVerificationController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignatureVerificationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureVerification> Get()
        {
            return _context.Set<ElectronicSignatureVerification>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ElectronicSignatureVerification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureVerification electronicSignatureVerification)
        {
            

            _context.Set<ElectronicSignatureVerification>().Add(electronicSignatureVerification);
            await _context.SaveChangesAsync();

            return Created(electronicSignatureVerification);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureVerification electronicSignatureVerification)
        {
            
            if (key != electronicSignatureVerification.ElectronicSignatureVerificationId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignatureVerification).State = EntityState.Modified;

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

            return Updated(electronicSignatureVerification);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureVerification> patch)
        {
            
            var entity = await _context.Set<ElectronicSignatureVerification>().FindAsync(key);
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
            var electronicSignatureVerification = await _context.Set<ElectronicSignatureVerification>().FindAsync(key);
            if (electronicSignatureVerification == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignatureVerification>().Remove(electronicSignatureVerification);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignatureVerification>().Any(e => e.ElectronicSignatureVerificationId == key);
        }
    }
}