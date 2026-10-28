using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ChecklistExecutionSectionController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistExecutionSectionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistExecutionSection> Get()
        {
            return _context.Set<ChecklistExecutionSection>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistExecutionSection>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistExecutionSection checklistExecutionSection)
        {
           
            _context.Set<ChecklistExecutionSection>().Add(checklistExecutionSection);
            await _context.SaveChangesAsync();

            return Created(checklistExecutionSection);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistExecutionSection checklistExecutionSection)
        {
            
            if (key != checklistExecutionSection.ChecklistExecutionSectionId)
            {
                return BadRequest();
            }

            _context.Entry(checklistExecutionSection).State = EntityState.Modified;

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

            return Updated(checklistExecutionSection);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistExecutionSection> patch)
        {
           
            var entity = await _context.Set<ChecklistExecutionSection>().FindAsync(key);
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
            var entity = await _context.Set<ChecklistExecutionSection>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistExecutionSection>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistExecutionSection>().Count(e => e.ChecklistExecutionSectionId == key) > 0;
        }
    }
}