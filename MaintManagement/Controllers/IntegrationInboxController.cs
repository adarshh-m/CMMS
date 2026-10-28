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
    public class IntegrationInboxController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationInboxController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationInbox> Get()
        {
            return _context.Set<IntegrationInbox>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<IntegrationInbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationInbox integrationInbox)
        {
            

            _context.Set<IntegrationInbox>().Add(integrationInbox);
            await _context.SaveChangesAsync();

            return Created(integrationInbox);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationInbox integrationInbox)
        {
           
            if (key != integrationInbox.InboxId)
            {
                return BadRequest();
            }

            _context.Entry(integrationInbox).State = EntityState.Modified;

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

            return Updated(integrationInbox);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationInbox> integrationInbox)
        {
            

            var entity = await _context.Set<IntegrationInbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationInbox.Patch(entity);

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
            var integrationInbox = await _context.Set<IntegrationInbox>().FindAsync(key);
            if (integrationInbox == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationInbox>().Remove(integrationInbox);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationInbox>().Count(e => e.InboxId == key) > 0;
        }
    }

    
}