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
    public class WorkOrderAssignmentController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkOrderAssignmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkOrderAssignment> Get()
        {
            return _context.Set<WorkOrderAssignment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var workOrderAssignment = await _context.Set<WorkOrderAssignment>().FindAsync(key);
            if (workOrderAssignment == null)
            {
                return NotFound();
            }
            return Ok(workOrderAssignment);
        }

        public async Task<IActionResult> Post([FromBody]WorkOrderAssignment workOrderAssignment)
        {
            
            workOrderAssignment.AssignmentId = Guid.NewGuid();
            _context.Set<WorkOrderAssignment>().Add(workOrderAssignment);
            await _context.SaveChangesAsync();

            return Created(workOrderAssignment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkOrderAssignment workOrderAssignment)
        {
           
            if (key != workOrderAssignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(workOrderAssignment).State = EntityState.Modified;

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

            return Updated(workOrderAssignment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<WorkOrderAssignment> workOrderAssignment)
        {
          

            var workassignment = await _context.Set<WorkOrderAssignment>().FindAsync(key);
            if (workassignment == null)
            {
                return NotFound();
            }

            workOrderAssignment.Patch(workassignment);

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

            return Updated(workassignment);
        }

        public async Task<IActionResult> Delete(Guid key)
        {
            var workOrderAssignment = await _context.Set<WorkOrderAssignment>().FindAsync(key);
            if (workOrderAssignment == null)
            {
                return NotFound();
            }

            _context.Set<WorkOrderAssignment>().Remove(workOrderAssignment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkOrderAssignment>().Count(e => e.AssignmentId == key) > 0;
        }
    }
}