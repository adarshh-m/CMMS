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
    public class WorkflowTransitionController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowTransitionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowTransition> Get()
        {
            return _context.Set<WorkflowTransition>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var entity = await _context.Set<WorkflowTransition>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowTransition workflowTransition)
        {
           workflowTransition.WorkflowTransitionId = Guid.NewGuid();
            _context.Set<WorkflowTransition>().Add(workflowTransition);
            await _context.SaveChangesAsync();

            return Created(workflowTransition);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowTransition workflowTransition)
        {
           
            if (key != workflowTransition.WorkflowTransitionId)
            {
                return BadRequest();
            }

            _context.Entry(workflowTransition).State = EntityState.Modified;

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

            return Updated(workflowTransition);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowTransition> patch)
        {
           
            var entity = await _context.Set<WorkflowTransition>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<WorkflowTransition>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowTransition>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowTransition>().Find(key) != null;
        }
    }

  
}