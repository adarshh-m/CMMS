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
    public class IntegrationScheduleController : ODataController
    {
        private readonly CmmsContext _context;

        public IntegrationScheduleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<IntegrationSchedule> Get()
        {
            return _context.Set<IntegrationSchedule>();
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationSchedule>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<IntegrationSchedule>().Where(x => x.IntegrationScheduleId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationSchedule integrationSchedule)
        {
            

            _context.Set<IntegrationSchedule>().Add(integrationSchedule);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(integrationSchedule.IntegrationScheduleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(integrationSchedule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] IntegrationSchedule integrationSchedule)
        {
            

            if (key != integrationSchedule.IntegrationScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(integrationSchedule).State = EntityState.Modified;

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

            return Updated(integrationSchedule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationSchedule> patch)
        {
           

            var integrationSchedule = await _context.Set<IntegrationSchedule>().FindAsync(key);
            if (integrationSchedule == null)
            {
                return NotFound();
            }

            patch.Patch(integrationSchedule);

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

            return Updated(integrationSchedule);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var integrationSchedule = await _context.Set<IntegrationSchedule>().FindAsync(key);
            if (integrationSchedule == null)
            {
                return NotFound();
            }

            _context.Set<IntegrationSchedule>().Remove(integrationSchedule);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<IntegrationSchedule>().Count(e => e.IntegrationScheduleId == key) > 0;
        }
    }
}