using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class EventDeadLetterController : ODataController
    {
        private readonly CmmsContext _context;

        public EventDeadLetterController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventDeadLetter> Get()
        {
            return _context.Set<EventDeadLetter>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<EventDeadLetter>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] EventDeadLetter eventDeadLetter)
        {
            
            _context.Set<EventDeadLetter>().Add(eventDeadLetter);
            await _context.SaveChangesAsync();

            return Created(eventDeadLetter);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventDeadLetter eventDeadLetter)
        {
            
            if (key != eventDeadLetter.EventDeadLetterId)
            {
                return BadRequest();
            }

            _context.Entry(eventDeadLetter).State = EntityState.Modified;

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

            return Updated(eventDeadLetter);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventDeadLetter> delta)
        {
           
            var entity = await _context.Set<EventDeadLetter>().FindAsync(key);
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
            var entity = await _context.Set<EventDeadLetter>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<EventDeadLetter>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<EventDeadLetter>().Count(e => e.EventDeadLetterId == key) > 0;
        }
    }
}