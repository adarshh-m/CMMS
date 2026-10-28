using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMCalendarRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public PMCalendarRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmcalendarRule> Get()
        {
            return _context.PmcalendarRules;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var pmCalendarRule = await _context.PmcalendarRules.FindAsync(key);
            if (pmCalendarRule == null)
            {
                return NotFound();
            }
            return Ok(pmCalendarRule);
        }

        public async Task<IActionResult> Post([FromBody] PmcalendarRule pmCalendarRule)
        {
            
            _context.PmcalendarRules.Add(pmCalendarRule);
            await _context.SaveChangesAsync();

            return Created(pmCalendarRule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmcalendarRule pmCalendarRule)
        {
            
            if (key != pmCalendarRule.PmcalendarRuleId)
            {
                return BadRequest();
            }

            _context.Entry(pmCalendarRule).State = EntityState.Modified;

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

            return Updated(pmCalendarRule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmcalendarRule> delta)
        {
            
            var pmCalendarRule = await _context.PmcalendarRules.FindAsync(key);
            if (pmCalendarRule == null)
            {
                return NotFound();
            }

            delta.Patch(pmCalendarRule);

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

            return Updated(pmCalendarRule);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var pmCalendarRule = await _context.PmcalendarRules.FindAsync(key);
            if (pmCalendarRule == null)
            {
                return NotFound();
            }

            _context.PmcalendarRules.Remove(pmCalendarRule);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.PmcalendarRules.Any(e => e.PmcalendarRuleId == key);
        }
    }
}