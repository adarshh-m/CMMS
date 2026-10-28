using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ChecklistQuestionOptionController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistQuestionOptionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistQuestionOption> Get()
        {
            return _context.Set<ChecklistQuestionOption>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistQuestionOption>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistQuestionOption checklistQuestionOption)
        {
            
            _context.Set<ChecklistQuestionOption>().Add(checklistQuestionOption);
            await _context.SaveChangesAsync();

            return Created(checklistQuestionOption);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistQuestionOption checklistQuestionOption)
        {
           
            if (key != checklistQuestionOption.ChecklistQuestionOptionId)
            {
                return BadRequest();
            }

            _context.Entry(checklistQuestionOption).State = EntityState.Modified;

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

            return Updated(checklistQuestionOption);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistQuestionOption> patch)
        {
            
            var entity = await _context.Set<ChecklistQuestionOption>().FindAsync(key);
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
            var checklistQuestionOption = await _context.Set<ChecklistQuestionOption>().FindAsync(key);
            if (checklistQuestionOption == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistQuestionOption>().Remove(checklistQuestionOption);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistQuestionOption>().Any(e => e.ChecklistQuestionOptionId == key);
        }
    }
}