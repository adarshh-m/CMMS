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
    public class WorkflowEscalationController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowEscalationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowEscalation> Get()
        {
            return _context.Set<WorkflowEscalation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<WorkflowEscalation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowEscalation workflowEscalation)
        {
           workflowEscalation.WorkflowEscalationId = Guid.NewGuid();
            _context.Set<WorkflowEscalation>().Add(workflowEscalation);
            await _context.SaveChangesAsync();

            return Created(workflowEscalation);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowEscalation workflowEscalation)
        {

            if (key != workflowEscalation.WorkflowEscalationId)
            {
                return BadRequest();
            }

            _context.Entry(workflowEscalation).State = EntityState.Modified;

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

            return Updated(workflowEscalation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowEscalation> delta)
        {
           
            var entity = await _context.Set<WorkflowEscalation>().FindAsync(key);
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
            var entity = await _context.Set<WorkflowEscalation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowEscalation>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowEscalation>().Count(e => e.WorkflowEscalationId == key) > 0;
        }
    }
}