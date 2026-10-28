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
    public class CalibrationOOTAssessmentController : ODataController
    {
        private readonly CmmsContext db;

        public CalibrationOOTAssessmentController(CmmsContext context)
        {
            db = context;
        }

        // GET: odata/CalibrationOOTAssessment
        [EnableQuery]
        public IQueryable<CalibrationOotassessment> Get()
        {
            return db.CalibrationOotassessments;
        }

        // GET: odata/CalibrationOOTAssessment(5)
        [EnableQuery]
        public SingleResult<CalibrationOotassessment> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.CalibrationOotassessments.Where(calibrationOOTAssessment => calibrationOOTAssessment.OotassessmentId == key));
        }

        // POST: odata/CalibrationOOTAssessment
        public async Task<IActionResult> Post([FromBody] CalibrationOotassessment calibrationOOTAssessment)
        {
           
            db.CalibrationOotassessments.Add(calibrationOOTAssessment);
            await db.SaveChangesAsync();

            return Created(calibrationOOTAssessment);
        }

        // PUT: odata/CalibrationOOTAssessment(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] CalibrationOotassessment calibrationOOTAssessment)
        {
            

            if (key != calibrationOOTAssessment.OotassessmentId)
            {
                return BadRequest();
            }

            db.Entry(calibrationOOTAssessment).State = EntityState.Modified;

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

            return Updated(calibrationOOTAssessment);
        }

        // PATCH: odata/CalibrationOOTAssessment(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<CalibrationOotassessment> patch)
        {
            

            CalibrationOotassessment calibrationOOTAssessment = await db.CalibrationOotassessments.FindAsync(key);
            if (calibrationOOTAssessment == null)
            {
                return NotFound();
            }

            patch.Patch(calibrationOOTAssessment);

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

            return Updated(calibrationOOTAssessment);
        }

        // DELETE: odata/CalibrationOOTAssessment(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            CalibrationOotassessment calibrationOOTAssessment = await db.CalibrationOotassessments.FindAsync(key);
            if (calibrationOOTAssessment == null)
            {
                return NotFound();
            }

            db.CalibrationOotassessments.Remove(calibrationOOTAssessment);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.CalibrationOotassessments.Count(e => e.OotassessmentId == key) > 0;
        }
    }
}