using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMScheduleChecklistController : ODataController
    {
        private readonly CmmsContext _context;

        public PMScheduleChecklistController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmscheduleChecklist> Get()
        {
            return _context.Set<PmscheduleChecklist>();
        }

        [EnableQuery]
        public async Task<SingleResult<PmscheduleChecklist>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<PmscheduleChecklist>().Where(p => p.PmscheduleChecklistId == key));
        }

        public async Task<IActionResult> Post([FromBody] PmscheduleChecklist pMScheduleChecklist)
        {
            
            _context.Set<PmscheduleChecklist>().Add(pMScheduleChecklist);
            await _context.SaveChangesAsync();

            return Created(pMScheduleChecklist);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmscheduleChecklist pMScheduleChecklist)
        {
            

            if (key != pMScheduleChecklist.PmscheduleChecklistId)
            {
                return BadRequest();
            }

            _context.Entry(pMScheduleChecklist).State = EntityState.Modified;

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

            return Updated(pMScheduleChecklist);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmscheduleChecklist> delta)
        {
            

            var entity = await _context.Set<PmscheduleChecklist>().FindAsync(key);
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
            var pMScheduleChecklist = await _context.Set<PmscheduleChecklist>().FindAsync(key);
            if (pMScheduleChecklist == null)
            {
                return NotFound();
            }

            _context.Set<PmscheduleChecklist>().Remove(pMScheduleChecklist);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmscheduleChecklist>().Count(e => e.PmscheduleChecklistId == key) > 0;
        }
    }
}