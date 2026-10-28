using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ReorderSuggestionController : ODataController
    {
        private readonly CmmsContext _context;

        public ReorderSuggestionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ReorderSuggestion> Get()
        {
            return _context.Set<ReorderSuggestion>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var reorderSuggestion = await _context.Set<ReorderSuggestion>().FindAsync(key);
            if (reorderSuggestion == null)
            {
                return NotFound();
            }
            return Ok(reorderSuggestion);
        }

        public async Task<IActionResult> Post([FromBody] ReorderSuggestion reorderSuggestion)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            reorderSuggestion.ReorderSuggestionId =Guid.NewGuid();
            _context.Set<ReorderSuggestion>().Add(reorderSuggestion);
            await _context.SaveChangesAsync();

            return Created(reorderSuggestion);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ReorderSuggestion reorderSuggestion)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != reorderSuggestion.ReorderSuggestionId)
            {
                return BadRequest();
            }

            _context.Entry(reorderSuggestion).State = EntityState.Modified;

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

            return Updated(reorderSuggestion);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ReorderSuggestion> reorderSuggestion)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var entity = await _context.Set<ReorderSuggestion>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            reorderSuggestion.Patch(entity);

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
            var reorderSuggestion = await _context.Set<ReorderSuggestion>().FindAsync(key);
            if (reorderSuggestion == null)
            {
                return NotFound();
            }

            _context.Set<ReorderSuggestion>().Remove(reorderSuggestion);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ReorderSuggestion>().Count(e => e.ReorderSuggestionId == key) > 0;
        }
    }
}