using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ChecklistVersionController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistVersionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistVersion> Get()
        {
            return _context.Set<ChecklistVersion>();
        }

        [EnableQuery]
        public async Task<SingleResult<ChecklistVersion>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<ChecklistVersion>().Where(c => c.ChecklistVersionId == key));
        }

        public async Task<IActionResult> Post([FromBody] ChecklistVersion checklistVersion)
        {
            

            _context.Set<ChecklistVersion>().Add(checklistVersion);
            await _context.SaveChangesAsync();

            return Created(checklistVersion);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistVersion checklistVersion)
        {
            

            if (key != checklistVersion.ChecklistVersionId)
            {
                return BadRequest();
            }

            _context.Entry(checklistVersion).State = EntityState.Modified;

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

            return Updated(checklistVersion);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistVersion> checklistVersion)
        {
            
            var entity = await _context.Set<ChecklistVersion>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            checklistVersion.Patch(entity);

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
            var checklistVersion = await _context.Set<ChecklistVersion>().FindAsync(key);
            if (checklistVersion == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistVersion>().Remove(checklistVersion);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistVersion>().Count(e => e.ChecklistVersionId == key) > 0;
        }
    }
}