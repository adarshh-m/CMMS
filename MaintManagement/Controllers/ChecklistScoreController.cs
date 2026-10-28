using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ChecklistScoreController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistScoreController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistScore> Get()
        {
            return _context.Set<ChecklistScore>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var checklistScore = await _context.Set<ChecklistScore>().FindAsync(key);
            if (checklistScore == null)
            {
                return NotFound();
            }
            return Ok(checklistScore);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistScore checklistScore)
        {
           

            _context.Set<ChecklistScore>().Add(checklistScore);
            await _context.SaveChangesAsync();

            return Created(checklistScore);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistScore checklistScore)
        {
            

            if (key != checklistScore.ChecklistScoreId)
            {
                return BadRequest();
            }

            _context.Entry(checklistScore).State = EntityState.Modified;

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

            return Updated(checklistScore);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistScore> checklistScore)
        {
            

            var entity = await _context.Set<ChecklistScore>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            checklistScore.Patch(entity);

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
            var checklistScore = await _context.Set<ChecklistScore>().FindAsync(key);
            if (checklistScore == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistScore>().Remove(checklistScore);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistScore>().Any(e => e.ChecklistScoreId == key);
        }
    }
}