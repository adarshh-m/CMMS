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
    public class WorkflowInstanceController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowInstanceController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowInstance> Get()
        {
            return _context.Set<WorkflowInstance>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var workflowInstance = await _context.Set<WorkflowInstance>().FindAsync(key);
            if (workflowInstance == null)
            {
                return NotFound();
            }
            return Ok(workflowInstance);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowInstance workflowInstance)
        {
          workflowInstance.WorkflowInstanceId = Guid.NewGuid();
            _context.Set<WorkflowInstance>().Add(workflowInstance);
            await _context.SaveChangesAsync();

            return Created(workflowInstance);
        }

        public async Task<IActionResult> Put( Guid key,[FromBody] WorkflowInstance workflowInstance)
        {
           
            if (key != workflowInstance.WorkflowInstanceId)
            {
                return BadRequest();
            }

            _context.Entry(workflowInstance).State = EntityState.Modified;

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

            return Updated(workflowInstance);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowInstance> delta)
        {
           
            var workflowInstance = await _context.Set<WorkflowInstance>().FindAsync(key);
            if (workflowInstance == null)
            {
                return NotFound();
            }

            delta.Patch(workflowInstance);

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

            return Updated(workflowInstance);
        }

        public async Task<IActionResult> Delete( Guid key)
        {
            var workflowInstance = await _context.Set<WorkflowInstance>().FindAsync(key);
            if (workflowInstance == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowInstance>().Remove(workflowInstance);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowInstance>().Any(e => e.WorkflowInstanceId == key);
        }
    }
}