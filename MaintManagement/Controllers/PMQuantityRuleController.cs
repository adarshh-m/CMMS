using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMQuantityRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public PMQuantityRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmquantityRule> Get()
        {
            return _context.Set<PmquantityRule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<PmquantityRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmquantityRule pMQuantityRule)
        {
            

            _context.Set<PmquantityRule>().Add(pMQuantityRule);
            await _context.SaveChangesAsync();

            return Created(pMQuantityRule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmquantityRule update)
        {
            

            if (key != update.PmquantityRuleId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PmquantityRule> patch)
        {
            

            var entity = await _context.Set<PmquantityRule>().FindAsync(key);
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
            var entity = await _context.Set<PmquantityRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PmquantityRule>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmquantityRule>().Count(e => e.PmquantityRuleId == key) > 0;
        }
    }
}