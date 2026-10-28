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
    public class WorkflowRoleAssignmentController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowRoleAssignmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowRoleAssignment> Get()
        {
            return _context.Set<WorkflowRoleAssignment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var workflowRoleAssignment = await _context.Set<WorkflowRoleAssignment>().FindAsync(key);
            if (workflowRoleAssignment == null)
            {
                return NotFound();
            }
            return Ok(workflowRoleAssignment);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowRoleAssignment workflowRoleAssignment)
        {
           workflowRoleAssignment.WorkflowRoleAssignmentId = Guid.NewGuid();
            _context.Set<WorkflowRoleAssignment>().Add(workflowRoleAssignment);
            await _context.SaveChangesAsync();

            return Created(workflowRoleAssignment);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] WorkflowRoleAssignment workflowRoleAssignment)
        {
           
            if (key != workflowRoleAssignment.WorkflowRoleAssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(workflowRoleAssignment).State = EntityState.Modified;

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

            return Updated(workflowRoleAssignment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowRoleAssignment> patch)
        {
          
            var workflowRoleAssignment = await _context.Set<WorkflowRoleAssignment>().FindAsync(key);
            if (workflowRoleAssignment == null)
            {
                return NotFound();
            }

            patch.Patch(workflowRoleAssignment);

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

            return Updated(workflowRoleAssignment);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workflowRoleAssignment = await _context.Set<WorkflowRoleAssignment>().FindAsync(key);
            if (workflowRoleAssignment == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowRoleAssignment>().Remove(workflowRoleAssignment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowRoleAssignment>().Find(key) != null;
        }
    }
}