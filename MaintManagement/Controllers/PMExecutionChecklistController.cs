using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMExecutionChecklistController : ODataController
    {
        private readonly CmmsContext db;

        public PMExecutionChecklistController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<PmexecutionChecklist> Get()
        {
            return db.PmexecutionChecklists;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            PmexecutionChecklist entity = await db.PmexecutionChecklists.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmexecutionChecklist pMExecutionChecklist)
        {
            
            db.PmexecutionChecklists.Add(pMExecutionChecklist);
            await db.SaveChangesAsync();

            return Created(pMExecutionChecklist);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] PmexecutionChecklist pMExecutionChecklist)
        {
           
            if (key != pMExecutionChecklist.PmexecutionChecklistId)
            {
                return BadRequest();
            }

            db.Entry(pMExecutionChecklist).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(pMExecutionChecklist);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PmexecutionChecklist> delta)
        {

            PmexecutionChecklist pMExecutionChecklist = await db.PmexecutionChecklists.FindAsync(key);
            if (pMExecutionChecklist == null)
            {
                return NotFound();
            }

            delta.Patch(pMExecutionChecklist);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(pMExecutionChecklist);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PmexecutionChecklist pMExecutionChecklist = await db.PmexecutionChecklists.FindAsync(key);
            if (pMExecutionChecklist == null)
            {
                return NotFound();
            }

            db.PmexecutionChecklists.Remove(pMExecutionChecklist);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PmexecutionChecklists.Count(e => e.PmexecutionChecklistId == key) > 0;
        }
    }
}