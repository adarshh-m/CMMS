using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 
 

namespace YourNamespace.Controllers
{
    public class PermitBlockingRuleController : ODataController
    {
     

        private readonly CmmsContext db;

        public PermitBlockingRuleController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<PermitBlockingRule> Get()
        {
            return db.PermitBlockingRules;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            PermitBlockingRule entity = await db.PermitBlockingRules.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PermitBlockingRule permitBlockingRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PermitBlockingRules.Add(permitBlockingRule);
            await db.SaveChangesAsync();

            return Created(permitBlockingRule);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitBlockingRule permitBlockingRule)
        {
            

            if (key != permitBlockingRule.PermitBlockingRuleId)
            {
                return BadRequest();
            }

            db.Entry(permitBlockingRule).State = EntityState.Modified;

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

            return Updated(permitBlockingRule);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitBlockingRule> patch)
        {
            

            PermitBlockingRule permitBlockingRule = await db.PermitBlockingRules.FindAsync(key);
            if (permitBlockingRule == null)
            {
                return NotFound();
            }

            patch.Patch(permitBlockingRule);

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

            return Updated(permitBlockingRule);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            PermitBlockingRule permitBlockingRule = await db.PermitBlockingRules.FindAsync(key);
            if (permitBlockingRule == null)
            {
                return NotFound();
            }

            db.PermitBlockingRules.Remove(permitBlockingRule);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.PermitBlockingRules.Count(e => e.PermitBlockingRuleId == key) > 0;
        }
    }
}