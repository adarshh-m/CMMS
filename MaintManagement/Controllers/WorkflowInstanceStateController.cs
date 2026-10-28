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
    public class WorkflowInstanceStateController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowInstanceStateController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowInstanceState> Get()
        {
            return _context.Set<WorkflowInstanceState>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<WorkflowInstanceState>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowInstanceState workflowInstanceState)
        {
           workflowInstanceState.WorkflowInstanceStateId = Guid.NewGuid();
            _context.Set<WorkflowInstanceState>().Add(workflowInstanceState);
            await _context.SaveChangesAsync();

            return Created(workflowInstanceState);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowInstanceState workflowInstanceState)
        {
            
            if (key != workflowInstanceState.WorkflowInstanceStateId)
            {
                return BadRequest();
            }

            _context.Entry(workflowInstanceState).State = EntityState.Modified;

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

            return Updated(workflowInstanceState);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowInstanceState> delta)
        {

            var entity = await _context.Set<WorkflowInstanceState>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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

        public async Task<IActionResult> Delete( Guid key)
        {
            var entity = await _context.Set<WorkflowInstanceState>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowInstanceState>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowInstanceState>().Find(key) != null;
        }
    }
}