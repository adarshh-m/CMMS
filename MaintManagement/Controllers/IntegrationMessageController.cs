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
    public class IntegrationMessageController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationMessageController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationMessage> Get()
        {
            return _context.Set<IntegrationMessage>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<IntegrationMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationMessage integrationMessage)
        {
            

            _context.Set<IntegrationMessage>().Add(integrationMessage);
            await _context.SaveChangesAsync();

            return Created(integrationMessage);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationMessage integrationMessage)
        {
            

            if (key != integrationMessage.IntegrationMessageId)
            {
                return BadRequest();
            }

            _context.Entry(integrationMessage).State = EntityState.Modified;

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

            return Updated(integrationMessage);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationMessage> delta)
        {
            

            var entity = await _context.Set<IntegrationMessage>().FindAsync(key);
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
            var entity = await _context.Set<IntegrationMessage>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationMessage>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationMessage>().Any(e => e.IntegrationMessageId == key);
        }
    }

}