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
    public class WorkflowStateController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowStateController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowState> Get()
        {
            return _context.Set<WorkflowState>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var entity = await _context.Set<WorkflowState>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowState workflowState)
        {
           workflowState.WorkflowStateId = Guid.NewGuid();
            _context.Set<WorkflowState>().Add(workflowState);
            await _context.SaveChangesAsync();

            return Created(workflowState);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowState workflowState)
        {
           
            if (key != workflowState.WorkflowStateId)
            {
                return BadRequest();
            }

            _context.Entry(workflowState).State = EntityState.Modified;

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

            return Updated(workflowState);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowState> delta)
        {
           
            var entity = await _context.Set<WorkflowState>().FindAsync(key);
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

        public async Task<IActionResult> Delete(Guid key)
        {
            var entity = await _context.Set<WorkflowState>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowState>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowState>().Any(e => e.WorkflowStateId == key);
        }
    }
}