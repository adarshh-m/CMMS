using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureRequestController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignatureRequestController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureRequest> Get()
        {
            return _context.Set<ElectronicSignatureRequest>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ElectronicSignatureRequest>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureRequest electronicSignatureRequest)
        {
           
            _context.Set<ElectronicSignatureRequest>().Add(electronicSignatureRequest);
            await _context.SaveChangesAsync();

            return Created(electronicSignatureRequest);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ElectronicSignatureRequest electronicSignatureRequest)
        {
           
            if (key != electronicSignatureRequest.ElectronicSignatureRequestId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignatureRequest).State = EntityState.Modified;

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

            return Updated(electronicSignatureRequest);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureRequest> delta)
        {
            
            var entity = await _context.Set<ElectronicSignatureRequest>().FindAsync(key);
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
            var electronicSignatureRequest = await _context.Set<ElectronicSignatureRequest>().FindAsync(key);
            if (electronicSignatureRequest == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignatureRequest>().Remove(electronicSignatureRequest);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignatureRequest>().Count(e => e.ElectronicSignatureRequestId == key) > 0;
        }
    }
}