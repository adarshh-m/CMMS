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
    public class WorkOrderController : ODataController
    {
        private readonly CmmsContext _context;

        public WorkOrderController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<WorkOrder> Get()
        {
            return _context.Set<WorkOrder>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var workOrder = await _context.Set<WorkOrder>().FindAsync(key);
            if (workOrder == null)
            {
                return NotFound();
            }
            return Ok(workOrder);
        }

        public async Task<IActionResult> Post([FromBody]WorkOrder workOrder)
        {
            workOrder.WorkOrderId = Guid.NewGuid();
            _context.Set<WorkOrder>().Add(workOrder);
            await _context.SaveChangesAsync();

            return Created(workOrder);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] WorkOrder workOrder)
        {
           

            if (key != workOrder.WorkOrderId)
            {
                return BadRequest();
            }

            _context.Entry(workOrder).State = EntityState.Modified;

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

            return Updated(workOrder);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<WorkOrder> workOrder)
        {
           
            var entity = await _context.Set<WorkOrder>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            workOrder.Patch(entity);

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
            var workOrder = await _context.Set<WorkOrder>().FindAsync(key);
            if (workOrder == null)
            {
                return NotFound();
            }

            _context.Set<WorkOrder>().Remove(workOrder);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<WorkOrder>().Any(e => e.WorkOrderId == key);
        }
    }
}