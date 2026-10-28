using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class BreakdownApprovalController : ODataController
    {
        private readonly CmmsContext db;

        public BreakdownApprovalController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<BreakdownApproval> Get()
        {
            return db.BreakdownApprovals;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            BreakdownApproval breakdownApproval = await db.BreakdownApprovals.FindAsync(key);
            if (breakdownApproval == null)
            {
                return NotFound();
            }
            return Ok(breakdownApproval);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownApproval breakdownApproval)
        {
            

            db.BreakdownApprovals.Add(breakdownApproval);
            await db.SaveChangesAsync();

            return Created(breakdownApproval);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] BreakdownApproval update)
        {
            
            if (key != update.ApprovalId)
            {
                return BadRequest();
            }

            db.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<BreakdownApproval> patch)
        {
           

            BreakdownApproval breakdownApproval = await db.BreakdownApprovals.FindAsync(key);
            if (breakdownApproval == null)
            {
                return NotFound();
            }

            patch.Patch(breakdownApproval);

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

            return Updated(breakdownApproval);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            BreakdownApproval breakdownApproval = await db.BreakdownApprovals.FindAsync(key);
            if (breakdownApproval == null)
            {
                return NotFound();
            }

            db.BreakdownApprovals.Remove(breakdownApproval);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.BreakdownApprovals.Count(e => e.ApprovalId == key) > 0;
        }
    }
}