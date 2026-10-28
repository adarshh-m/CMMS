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
    public class CalibrationStandardController : ODataController
    {
        private readonly CmmsContext db;

        public CalibrationStandardController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<CalibrationStandard> Get()
        {
            return db.CalibrationStandards;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            CalibrationStandard calibrationStandard = await db.CalibrationStandards.FindAsync(key);
            if (calibrationStandard == null)
            {
                return NotFound();
            }
            return Ok(calibrationStandard);
        }

        public async Task<IActionResult> Post([FromBody] CalibrationStandard calibrationStandard)
        {
            

            db.CalibrationStandards.Add(calibrationStandard);
            await db.SaveChangesAsync();

            return Created(calibrationStandard);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] CalibrationStandard calibrationStandard)
        {
            
            if (key != calibrationStandard.CalibrationStandardId)
            {
                return BadRequest();
            }

            db.Entry(calibrationStandard).State = EntityState.Modified;

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

            return Updated(calibrationStandard);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<CalibrationStandard> patch)
        {
            

            CalibrationStandard calibrationStandard = await db.CalibrationStandards.FindAsync(key);
            if (calibrationStandard == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationStandard);

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

            return Updated(calibrationStandard);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            CalibrationStandard calibrationStandard = await db.CalibrationStandards.FindAsync(key);
            if (calibrationStandard == null)
            {
                return NotFound();
            }

            db.CalibrationStandards.Remove(calibrationStandard);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.CalibrationStandards.Any(e => e.CalibrationStandardId == key);
        }
    }
}