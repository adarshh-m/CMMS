using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMScheduleController : ODataController
    {
        private readonly CmmsContext _context;

        public PMScheduleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Pmschedule> Get()
        {
            return _context.Set<Pmschedule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<Pmschedule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] Pmschedule pMSchedule)
        {
           
            _context.Set<Pmschedule>().Add(pMSchedule);
            await _context.SaveChangesAsync();

            return Created(pMSchedule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Pmschedule pMSchedule)
        {
            
            if (key != pMSchedule.PmscheduleId)
            {
                return BadRequest();
            }

            _context.Entry(pMSchedule).State = EntityState.Modified;

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

            return Updated(pMSchedule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Pmschedule> patch)
        {
            
            var entity = await _context.Set<Pmschedule>().FindAsync(key);
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
            var entity = await _context.Set<Pmschedule>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<Pmschedule>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Pmschedule>().Count(e => e.PmscheduleId == key) > 0;
        }
    }
}