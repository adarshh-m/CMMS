using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignaturePolicyController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignaturePolicyController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignaturePolicy> Get()
        {
            return _context.Set<ElectronicSignaturePolicy>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var entity = await _context.Set<ElectronicSignaturePolicy>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignaturePolicy electronicSignaturePolicy)
        {
            electronicSignaturePolicy.ElectronicSignaturePolicyId = Guid.NewGuid();
            _context.Set<ElectronicSignaturePolicy>().Add(electronicSignaturePolicy);
            await _context.SaveChangesAsync();

            return Created(electronicSignaturePolicy);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignaturePolicy electronicSignaturePolicy)
        {
           
            if (key != electronicSignaturePolicy.ElectronicSignaturePolicyId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignaturePolicy).State = EntityState.Modified;

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

            return Updated(electronicSignaturePolicy);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignaturePolicy> delta)
        {
            
            var entity = await _context.Set<ElectronicSignaturePolicy>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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
            var electronicSignaturePolicy = await _context.Set<ElectronicSignaturePolicy>().FindAsync(key);
            if (electronicSignaturePolicy == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignaturePolicy>().Remove(electronicSignaturePolicy);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignaturePolicy>().Any(e => e.ElectronicSignaturePolicyId == key);
        }
    }
}