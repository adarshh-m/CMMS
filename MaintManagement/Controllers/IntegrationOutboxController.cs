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
    public class IntegrationOutboxController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationOutboxController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationOutbox> Get()
        {
            return _context.Set<IntegrationOutbox>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<IntegrationOutbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationOutbox integrationOutbox)
        {
            

            _context.Set<IntegrationOutbox>().Add(integrationOutbox);
            await _context.SaveChangesAsync();

            return Created(integrationOutbox);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationOutbox integrationOutbox)
        {
           
            if (key != integrationOutbox.OutboxId)
            {
                return BadRequest();
            }

            _context.Entry(integrationOutbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(integrationOutbox);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationOutbox> delta)
        {
            

            var entity = await _context.Set<IntegrationOutbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<IntegrationOutbox>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationOutbox>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationOutbox>().Count(e => e.OutboxId == key) > 0;
        }
    }
}