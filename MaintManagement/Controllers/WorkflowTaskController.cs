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
    public class WorkflowTaskController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowTaskController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowTask> Get()
        {
            return _context.Set<WorkflowTask>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var workflowTask = await _context.Set<WorkflowTask>().FindAsync(key);
            if (workflowTask == null)
            {
                return NotFound();
            }
            return Ok(workflowTask);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowTask workflowTask)
        {
           workflowTask.WorkflowTaskId = Guid.NewGuid();
            _context.Set<WorkflowTask>().Add(workflowTask);
            await _context.SaveChangesAsync();

            return Created(workflowTask);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowTask update)
        {
           
            if (key != update.WorkflowTaskId)
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

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowTask> patch)
        {
          
            var workflowTask = await _context.Set<WorkflowTask>().FindAsync(key);
            if (workflowTask == null)
            {
                return NotFound();
            }

            patch.Patch(workflowTask);

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

            return Updated(workflowTask);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workflowTask = await _context.Set<WorkflowTask>().FindAsync(key);
            if (workflowTask == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowTask>().Remove(workflowTask);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowTask>().Count(e => e.WorkflowTaskId == key) > 0;
        }
    }

    
}