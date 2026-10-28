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
    public class CalibrationExecutionController : ODataController
    {
        private readonly CmmsContext db;

        public CalibrationExecutionController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<CalibrationExecution> Get()
        {
            return db.CalibrationExecutions;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            CalibrationExecution calibrationExecution = await db.CalibrationExecutions.FindAsync(key);
            if (calibrationExecution == null)
            {
                return NotFound();
            }
            return Ok(calibrationExecution);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationExecution calibrationExecution)
        {
           

            db.CalibrationExecutions.Add(calibrationExecution);
            await db.SaveChangesAsync();

            return Created(calibrationExecution);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] CalibrationExecution calibrationExecution)
        {
            
            if (key != calibrationExecution.CalibrationExecutionId)
            {
                return BadRequest();
            }

            db.Entry(calibrationExecution).State = EntityState.Modified;

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

            return Updated(calibrationExecution);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationExecution> patch)
        {
            
            CalibrationExecution calibrationExecution = await db.CalibrationExecutions.FindAsync(key);
            if (calibrationExecution == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationExecution);

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

            return Updated(calibrationExecution);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            CalibrationExecution calibrationExecution = await db.CalibrationExecutions.FindAsync(key);
            if (calibrationExecution == null)
            {
                return NotFound();
            }

            db.CalibrationExecutions.Remove(calibrationExecution);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.CalibrationExecutions.Count(e => e.CalibrationExecutionId == key) > 0;
        }
    }
}