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
    public class WorkflowCommentController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowCommentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowComment> Get()
        {
            return _context.Set<WorkflowComment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var workflowComment = await _context.Set<WorkflowComment>().FindAsync(key);
            if (workflowComment == null)
            {
                return NotFound();
            }
            return Ok(workflowComment);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowComment workflowComment)
        {
            workflowComment.WorkflowCommentId = Guid.NewGuid(); 
            _context.Set<WorkflowComment>().Add(workflowComment);
            await _context.SaveChangesAsync();

            return Created(workflowComment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowComment workflowComment)
        {

            if (key != workflowComment.WorkflowCommentId)
            {
                return BadRequest();
            }

            _context.Entry(workflowComment).State = EntityState.Modified;

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

            return Updated(workflowComment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowComment> patch)
        {
            var workflowComment = await _context.Set<WorkflowComment>().FindAsync(key);
            if (workflowComment == null)
            {
                return NotFound();
            }

            patch.Patch(workflowComment);

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

            return Updated(workflowComment);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workflowComment = await _context.Set<WorkflowComment>().FindAsync(key);
            if (workflowComment == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowComment>().Remove(workflowComment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowComment>().Any(e => e.WorkflowCommentId == key);
        }
    }
}