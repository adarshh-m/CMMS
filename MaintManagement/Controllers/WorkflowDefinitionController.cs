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
    public class WorkflowDefinitionController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowDefinitionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowDefinition> Get()
        {
            return _context.WorkflowDefinitions;
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var workflowDefinition = await _context.WorkflowDefinitions.FindAsync(key);
            if (workflowDefinition == null)
            {
                return NotFound();
            }
            return Ok(workflowDefinition);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowDefinition workflowDefinition)
        {
           workflowDefinition.WorkflowDefinitionId = Guid.NewGuid();
            _context.WorkflowDefinitions.Add(workflowDefinition);
            await _context.SaveChangesAsync();

            return Created(workflowDefinition);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] WorkflowDefinition update)
        {
            
            if (key != update.WorkflowDefinitionId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowDefinition> patch)
        {
           
            var workflowDefinition = await _context.WorkflowDefinitions.FindAsync(key);
            if (workflowDefinition == null)
            {
                return NotFound();
            }

            patch.Patch(workflowDefinition);

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

            return Updated(workflowDefinition);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workflowDefinition = await _context.WorkflowDefinitions.FindAsync(key);
            if (workflowDefinition == null)
            {
                return NotFound();
            }

            _context.WorkflowDefinitions.Remove(workflowDefinition);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.WorkflowDefinitions.Any(e => e.WorkflowDefinitionId == key);
        }
    }
}