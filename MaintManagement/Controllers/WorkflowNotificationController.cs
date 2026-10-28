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
    public class WorkflowNotificationController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkflowNotificationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkflowNotification> Get()
        {
            return _context.Set<WorkflowNotification>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<WorkflowNotification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]WorkflowNotification workflowNotification)
        {
            workflowNotification.WorkflowNotificationId = Guid.NewGuid();
            _context.Set<WorkflowNotification>().Add(workflowNotification);
            await _context.SaveChangesAsync();

            return Created(workflowNotification);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkflowNotification workflowNotification)
        {
          
            if (key != workflowNotification.WorkflowNotificationId)
            {
                return BadRequest();
            }

            _context.Entry(workflowNotification).State = EntityState.Modified;

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

            return Updated(workflowNotification);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkflowNotification> delta)
        {
            
            var entity = await _context.Set<WorkflowNotification>().FindAsync(key);
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
            var entity = await _context.Set<WorkflowNotification>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<WorkflowNotification>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkflowNotification>().Count(e => e.WorkflowNotificationId == key) > 0;
        }
    }
}