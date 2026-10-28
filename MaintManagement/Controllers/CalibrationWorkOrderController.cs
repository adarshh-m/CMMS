using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 
 

namespace YourNamespace.Controllers
{
    public class CalibrationWorkOrderController : ODataController
    {
        private readonly CmmsContext db;

        public CalibrationWorkOrderController(CmmsContext context)
        {
            db = context;
        }

        // GET: odata/CalibrationWorkOrder
        [EnableQuery]
        public IQueryable<CalibrationWorkOrder> Get()
        {
            return db.CalibrationWorkOrders;
        }

        // GET: odata/CalibrationWorkOrder(5)
        [EnableQuery]
        public SingleResult<CalibrationWorkOrder> Get( Guid key)
        {
            return SingleResult.Create(db.CalibrationWorkOrders.Where(calibrationWorkOrder => calibrationWorkOrder.CalibrationWorkOrderId == key));
        }

        // POST: odata/CalibrationWorkOrder
        public async Task<IActionResult> Post([FromBody] CalibrationWorkOrder calibrationWorkOrder)
        {
           

            db.CalibrationWorkOrders.Add(calibrationWorkOrder);
            await db.SaveChangesAsync();

            return Created(calibrationWorkOrder);
        }

        // PUT: odata/CalibrationWorkOrder(5)
        public async Task<IActionResult> Put( Guid key, [FromBody] CalibrationWorkOrder calibrationWorkOrder)
        {
           

            if (key != calibrationWorkOrder.CalibrationWorkOrderId)
            {
                return BadRequest();
            }

            db.Entry(calibrationWorkOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(calibrationWorkOrder);
        }

        // PATCH: odata/CalibrationWorkOrder(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationWorkOrder> delta)
        {
            

            CalibrationWorkOrder calibrationWorkOrder = await db.CalibrationWorkOrders.FindAsync(key);
            if (calibrationWorkOrder == null)
            {
                return NotFound();
            }

            delta.Patch(calibrationWorkOrder);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(calibrationWorkOrder);
        }

        // DELETE: odata/CalibrationWorkOrder(5)
        public async Task<IActionResult> Delete( Guid key)
        {
            CalibrationWorkOrder calibrationWorkOrder = await db.CalibrationWorkOrders.FindAsync(key);
            if (calibrationWorkOrder == null)
            {
                return NotFound();
            }

            db.CalibrationWorkOrders.Remove(calibrationWorkOrder);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.CalibrationWorkOrders.Count(e => e.CalibrationWorkOrderId == key) > 0;
        }
    }
}