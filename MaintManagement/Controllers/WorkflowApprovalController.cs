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
    public class WorkflowApprovalController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowApprovalController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowApproval> Get()
        {
            return _context.Set<WorkflowApproval>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var workflowApproval = await _context.Set<WorkflowApproval>().FindAsync(key);
            if (workflowApproval == null)
            {
                return NotFound();
            }
            return Ok(workflowApproval);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowApproval workflowApproval)
        {
           workflowApproval.WorkflowApprovalId = Guid.NewGuid();
            _context.Set<WorkflowApproval>().Add(workflowApproval);
            await _context.SaveChangesAsync();

            return Created(workflowApproval);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] WorkflowApproval workflowApproval)
        {
           
            if (key != workflowApproval.WorkflowApprovalId)
            {
                return BadRequest();
            }

            _context.Entry(workflowApproval).State = EntityState.Modified;

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

            return Updated(workflowApproval);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowApproval> patch)
        {
            
            var workflowApproval = await _context.Set<WorkflowApproval>().FindAsync(key);
            if (workflowApproval == null)
            {
                return NotFound();
            }

            patch.Patch(workflowApproval);

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

            return Updated(workflowApproval);
        }

        public async Task<IActionResult> Delete( Guid key)
        {
            var workflowApproval = await _context.Set<WorkflowApproval>().FindAsync(key);
            if (workflowApproval == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowApproval>().Remove(workflowApproval);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowApproval>().Count(e => e.WorkflowApprovalId == key) > 0;
        }
    }
}