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
    public class IntegrationSystemController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationSystemController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationSystem> Get()
        {
            return _context.Set<IntegrationSystem>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var integrationSystem = await _context.Set<IntegrationSystem>().FindAsync(key);
            if (integrationSystem == null)
            {
                return NotFound();
            }
            return Ok(integrationSystem);
        }

        public async Task<IActionResult> Post([FromBody] IntegrationSystem integrationSystem)
        {
           

            _context.Set<IntegrationSystem>().Add(integrationSystem);
            await _context.SaveChangesAsync();

            return Created(integrationSystem);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationSystem integrationSystem)
        {
            

            if (key != integrationSystem.IntegrationSystemId)
            {
                return BadRequest();
            }

            _context.Entry(integrationSystem).State = EntityState.Modified;

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

            return Updated(integrationSystem);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationSystem> integrationSystem)
        {
            

            var entity = await _context.Set<IntegrationSystem>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationSystem.Patch(entity);

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
            var integrationSystem = await _context.Set<IntegrationSystem>().FindAsync(key);
            if (integrationSystem == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationSystem>().Remove(integrationSystem);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationSystem>().Count(e => e.IntegrationSystemId == key) > 0;
        }
    }
}