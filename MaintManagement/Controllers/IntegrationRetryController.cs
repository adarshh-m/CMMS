using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
using System.Linq;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class IntegrationRetryController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationRetryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationRetry> Get()
        {
            return _context.Set<IntegrationRetry>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var integrationRetry = await _context.Set<IntegrationRetry>().FindAsync(key);
            if (integrationRetry == null)
            {
                return NotFound();
            }
            return Ok(integrationRetry);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationRetry integrationRetry)
        {
            
            _context.Set<IntegrationRetry>().Add(integrationRetry);
            await _context.SaveChangesAsync();
            return Created(integrationRetry);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationRetry integrationRetry)
        {
            
            if (key != integrationRetry.IntegrationRetryId)
            {
                return BadRequest();
            }
            _context.Entry(integrationRetry).State = EntityState.Modified;
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
            return Updated(integrationRetry);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationRetry> integrationRetry)
        {
           
            var entity = await _context.Set<IntegrationRetry>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            integrationRetry.Patch(entity);
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
            var integrationRetry = await _context.Set<IntegrationRetry>().FindAsync(key);
            if (integrationRetry == null)
            {
                return NotFound();
            }
            _context.Set<IntegrationRetry>().Remove(integrationRetry);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationRetry>().Any(e => e.IntegrationRetryId == key);
        }
    }
}