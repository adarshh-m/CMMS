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
    public class WorkflowHistoryController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowHistoryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowHistory> Get()
        {
            return _context.Set<WorkflowHistory>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<WorkflowHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowHistory workflowHistory)
        {
            workflowHistory.WorkflowHistoryId = Guid.NewGuid();
            _context.Set<WorkflowHistory>().Add(workflowHistory);
            await _context.SaveChangesAsync();

            return Created(workflowHistory);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowHistory workflowHistory)
        {
           
            if (key != workflowHistory.WorkflowHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(workflowHistory).State = EntityState.Modified;

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

            return Updated(workflowHistory);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkflowHistory> delta)
        {
           
            var entity = await _context.Set<WorkflowHistory>().FindAsync(key);
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
            var entity = await _context.Set<WorkflowHistory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowHistory>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowHistory>().Find(key) != null;
        }
    }
}