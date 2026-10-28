using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class EventConsumerOffsetController : ODataController
    {
        private readonly CmmsContext _context;

        public EventConsumerOffsetController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<EventConsumerOffset> Get()
        {
            return _context.EventConsumerOffsets;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var eventConsumerOffset = await _context.EventConsumerOffsets.FindAsync(key);
            if (eventConsumerOffset == null)
            {
                return NotFound();
            }
            return Ok(eventConsumerOffset);
        }

        public async Task<IActionResult> Post([FromBody] EventConsumerOffset eventConsumerOffset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventConsumerOffsets.Add(eventConsumerOffset);
            await _context.SaveChangesAsync();

            return Created(eventConsumerOffset);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] EventConsumerOffset eventConsumerOffset)
        {
            
            if (key != eventConsumerOffset.EventConsumerOffsetId)
            {
                return BadRequest();
            }

            _context.Entry(eventConsumerOffset).State = EntityState.Modified;

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

            return Updated(eventConsumerOffset);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<EventConsumerOffset> patch)
        {
            
            var eventConsumerOffset = await _context.EventConsumerOffsets.FindAsync(key);
            if (eventConsumerOffset == null)
            {
                return NotFound();
            }

            patch.Patch(eventConsumerOffset);

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

            return Updated(eventConsumerOffset);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var eventConsumerOffset = await _context.EventConsumerOffsets.FindAsync(key);
            if (eventConsumerOffset == null)
            {
                return NotFound();
            }

            _context.EventConsumerOffsets.Remove(eventConsumerOffset);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.EventConsumerOffsets.Any(e => e.EventConsumerOffsetId == key);
        }
    }
}