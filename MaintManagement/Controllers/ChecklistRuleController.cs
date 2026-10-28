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
    public class ChecklistRuleController : ODataController
    {
        private readonly CmmsContext db;

        public ChecklistRuleController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<ChecklistRule> Get()
        {
            return db.ChecklistRules;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            ChecklistRule checklistRule = await db.ChecklistRules.FindAsync(key);
            if (checklistRule == null)
            {
                return NotFound();
            }
            return Ok(checklistRule);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistRule checklistRule)
        {
            

            db.ChecklistRules.Add(checklistRule);
            await db.SaveChangesAsync();

            return Created(checklistRule);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] ChecklistRule checklistRule)
        {
            

            if (key != checklistRule.ChecklistRuleId)
            {
                return BadRequest();
            }

            db.Entry(checklistRule).State = EntityState.Modified;

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

            return Updated(checklistRule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistRule> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ChecklistRule checklistRule = await db.ChecklistRules.FindAsync(key);
            if (checklistRule == null)
            {
                return NotFound();
            }

            delta.Patch(checklistRule);

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

            return Updated(checklistRule);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ChecklistRule checklistRule = await db.ChecklistRules.FindAsync(key);
            if (checklistRule == null)
            {
                return NotFound();
            }

            db.ChecklistRules.Remove(checklistRule);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ChecklistRules.Count(e => e.ChecklistRuleId == key) > 0;
        }
    }
}