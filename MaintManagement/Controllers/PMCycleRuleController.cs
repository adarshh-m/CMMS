using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMCycleRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public PMCycleRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmcycleRule> Get()
        {
            return _context.Set<PmcycleRule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<PmcycleRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmcycleRule entity)
        {
            
            _context.Set<PmcycleRule>().Add(entity);
            await _context.SaveChangesAsync();

            return Created(entity);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmcycleRule update)
        {
           
            if (key != update.PmcycleRuleId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmcycleRule> patch)
        {
            
            var entity = await _context.Set<PmcycleRule>().FindAsync(key);
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
            var entity = await _context.Set<PmcycleRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PmcycleRule>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmcycleRule>().Find(key) != null;
        }
    }
}