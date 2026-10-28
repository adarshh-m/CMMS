using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class PermitIssueController : ODataController
    {
        private readonly CmmsContext db;

        public PermitIssueController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<PermitIssue> Get()
        {
            return db.PermitIssues;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            PermitIssue permitIssue = await db.PermitIssues.FindAsync(key);
            if (permitIssue == null)
            {
                return NotFound();
            }
            return Ok(permitIssue);
        }

        public async Task<IActionResult> Post([FromBody] PermitIssue permitIssue)
        {
           

            db.PermitIssues.Add(permitIssue);
            await db.SaveChangesAsync();

            return Created(permitIssue);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitIssue update)
        {
            

            if (key != update.PermitIssueId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitIssue> patch)
        {
           

            PermitIssue permitIssue = await db.PermitIssues.FindAsync(key);
            if (permitIssue == null)
            {
                return NotFound();
            }

            patch.Patch(permitIssue);

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

            return Updated(permitIssue);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PermitIssue permitIssue = await db.PermitIssues.FindAsync(key);
            if (permitIssue == null)
            {
                return NotFound();
            }

            db.PermitIssues.Remove(permitIssue);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PermitIssues.Count(e => e.PermitIssueId == key) > 0;
        }
    }
}