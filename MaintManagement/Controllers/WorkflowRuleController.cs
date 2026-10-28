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
    public class WorkflowRuleController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowRuleController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowRule> Get()
        {
            return _context.Set<WorkflowRule>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var workflowRule = await _context.Set<WorkflowRule>().FindAsync(key);
            if (workflowRule == null)
            {
                return NotFound();
            }
            return Ok(workflowRule);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowRule workflowRule)
        {
           workflowRule.WorkflowRuleId = Guid.NewGuid();
            _context.Set<WorkflowRule>().Add(workflowRule);
            await _context.SaveChangesAsync();

            return Created(workflowRule);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowRule workflowRule)
        {
           
            if (key != workflowRule.WorkflowRuleId)
            {
                return BadRequest();
            }

            _context.Entry(workflowRule).State = EntityState.Modified;

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

            return Updated(workflowRule);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowRule> patch)
        {
           
            var workflowRule = await _context.Set<WorkflowRule>().FindAsync(key);
            if (workflowRule == null)
            {
                return NotFound();
            }

            patch.Patch(workflowRule);

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

            return Updated(workflowRule);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workflowRule = await _context.Set<WorkflowRule>().FindAsync(key);
            if (workflowRule == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowRule>().Remove(workflowRule);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowRule>().Find(key) != null;
        }
    }
}