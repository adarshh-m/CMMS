using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ChecklistExecutionController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistExecutionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistExecution> Get()
        {
            return _context.Set<ChecklistExecution>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistExecution>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistExecution checklistExecution)
        {
           
            _context.Set<ChecklistExecution>().Add(checklistExecution);
            await _context.SaveChangesAsync();

            return Created(checklistExecution);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistExecution checklistExecution)
        {
            
            if (key != checklistExecution.ChecklistExecutionId)
            {
                return BadRequest();
            }

            _context.Entry(checklistExecution).State = EntityState.Modified;

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

            return Updated(checklistExecution);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistExecution> checklistExecution)
        {
           
            var entity = await _context.Set<ChecklistExecution>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            checklistExecution.Patch(entity);

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
            var checklistExecution = await _context.Set<ChecklistExecution>().FindAsync(key);
            if (checklistExecution == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistExecution>().Remove(checklistExecution);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistExecution>().Count(e => e.ChecklistExecutionId == key) > 0;
        }
    }
}