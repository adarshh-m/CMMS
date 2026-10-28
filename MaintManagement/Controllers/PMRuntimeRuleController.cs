using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMRuntimeRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public PMRuntimeRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmruntimeRule> Get()
        {
            return _context.Set<PmruntimeRule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<PmruntimeRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmruntimeRule pMRuntimeRule)
        {
           

            _context.Set<PmruntimeRule>().Add(pMRuntimeRule);
            await _context.SaveChangesAsync();

            return Created(pMRuntimeRule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmruntimeRule pMRuntimeRule)
        {
            

            if (key != pMRuntimeRule.PmruntimeRuleId)
            {
                return BadRequest();
            }

            _context.Entry(pMRuntimeRule).State = EntityState.Modified;

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

            return Updated(pMRuntimeRule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmruntimeRule> delta)
        {
            
            var entity = await _context.Set<PmruntimeRule>().FindAsync(key);
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
            var entity = await _context.Set<PmruntimeRule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PmruntimeRule>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmruntimeRule>().Count(e => e.PmruntimeRuleId == key) > 0;
        }
    }
}