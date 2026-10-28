using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class PMTriggerHistoryController : ODataController
    {
        private readonly CmmsContext _context;

        public PMTriggerHistoryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmtriggerHistory> Get()
        {
            return _context.Set<PmtriggerHistory>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<PmtriggerHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmtriggerHistory pMTriggerHistory)
        {
           

            _context.Set<PmtriggerHistory>().Add(pMTriggerHistory);
            await _context.SaveChangesAsync();

            return Created(pMTriggerHistory);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] PmtriggerHistory pMTriggerHistory)
        {
            

            if (key != pMTriggerHistory.PmtriggerHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(pMTriggerHistory).State = EntityState.Modified;

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

            return Updated(pMTriggerHistory);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmtriggerHistory> delta)
        {
           

            var entity = await _context.Set<PmtriggerHistory>().FindAsync(key);
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
            var entity = await _context.Set<PmtriggerHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PmtriggerHistory>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmtriggerHistory>().Count(e => e.PmtriggerHistoryId == key) > 0;
        }
    }
}