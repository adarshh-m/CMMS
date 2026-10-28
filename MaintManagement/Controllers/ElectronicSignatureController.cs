using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignatureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignature> Get()
        {
            return _context.Set<ElectronicSignature>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var electronicSignature = await _context.Set<ElectronicSignature>().FindAsync(key);
            if (electronicSignature == null)
            {
                return NotFound();
            }
            return Ok(electronicSignature);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignature electronicSignature)
        {
           

            _context.Set<ElectronicSignature>().Add(electronicSignature);
            await _context.SaveChangesAsync();

            return Created(electronicSignature);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignature electronicSignature)
        {
            

            if (key != electronicSignature.ElectronicSignatureId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignature).State = EntityState.Modified;

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

            return Updated(electronicSignature);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignature> patch)
        {
           
            var electronicSignature = await _context.Set<ElectronicSignature>().FindAsync(key);
            if (electronicSignature == null)
            {
                return NotFound();
            }

            patch.Patch(electronicSignature);

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

            return Updated(electronicSignature);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var electronicSignature = await _context.Set<ElectronicSignature>().FindAsync(key);
            if (electronicSignature == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignature>().Remove(electronicSignature);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignature>().Count(e => e.ElectronicSignatureId == key) > 0;
        }
    }
}