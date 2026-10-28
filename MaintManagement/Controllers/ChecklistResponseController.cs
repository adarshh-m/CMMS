using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ChecklistResponseController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistResponseController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistResponse> Get()
        {
            return _context.Set<ChecklistResponse>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistResponse>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistResponse checklistResponse)
        {
           
            _context.Set<ChecklistResponse>().Add(checklistResponse);
            await _context.SaveChangesAsync();

            return Created(checklistResponse);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistResponse checklistResponse)
        {
            
            if (key != checklistResponse.ChecklistResponseId)
            {
                return BadRequest();
            }

            _context.Entry(checklistResponse).State = EntityState.Modified;

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

            return Updated(checklistResponse);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistResponse> checklistResponse)
        {
           
            var entity = await _context.Set<ChecklistResponse>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            checklistResponse.Patch(entity);

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
            var checklistResponse = await _context.Set<ChecklistResponse>().FindAsync(key);
            if (checklistResponse == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistResponse>().Remove(checklistResponse);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistResponse>().Count(e => e.ChecklistResponseId == key) > 0;
        }
    }
}