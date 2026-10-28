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
    public class WorkflowActionController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowActionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowAction> Get()
        {
            return _context.WorkflowActions;
        }

        [EnableQuery]
        public async Task<SingleResult<WorkflowAction>> Get(Guid key)
        {
            return SingleResult.Create(_context.WorkflowActions.Where(workflowAction => workflowAction.WorkflowActionId == key));
        }

        public async Task<IActionResult> Post([FromBody]WorkflowAction workflowAction)
        {
           workflowAction.WorkflowActionId = Guid.NewGuid();
            _context.WorkflowActions.Add(workflowAction);
            await _context.SaveChangesAsync();

            return Created(workflowAction);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] WorkflowAction workflowAction)
        {
            if (key != workflowAction.WorkflowActionId)
            {
                return BadRequest();
            }

            _context.Entry(workflowAction).State = EntityState.Modified;

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

            return Updated(workflowAction);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowAction> patch)
        {
            var workflowAction = await _context.WorkflowActions.FindAsync(key);
            if (workflowAction == null)
            {
                return NotFound();
            }

            patch.Patch(workflowAction);

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

            return Updated(workflowAction);
        }

        public async Task<IActionResult> Delete( Guid key)
        {
            var workflowAction = await _context.WorkflowActions.FindAsync(key);
            if (workflowAction == null)
            {
                return NotFound();
            }

            _context.WorkflowActions.Remove(workflowAction);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.WorkflowActions.Any(e => e.WorkflowActionId == key);
        }
    }
}