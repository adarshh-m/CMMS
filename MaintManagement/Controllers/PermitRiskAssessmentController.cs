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
    public class PermitRiskAssessmentController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitRiskAssessmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitRiskAssessment> Get()
        {
            return _context.Set<PermitRiskAssessment>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<PermitRiskAssessment>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody]PermitRiskAssessment permitRiskAssessment)
        {
           

            _context.Set<PermitRiskAssessment>().Add(permitRiskAssessment);
            await _context.SaveChangesAsync();

            return Created(permitRiskAssessment);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitRiskAssessment permitRiskAssessment)
        {
            
            if (key != permitRiskAssessment.PermitRiskAssessmentId)
            {
                return BadRequest();
            }

            _context.Entry(permitRiskAssessment).State = EntityState.Modified;

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

            return Updated(permitRiskAssessment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitRiskAssessment> delta)
        {
            

            var entity = await _context.Set<PermitRiskAssessment>().FindAsync(key);
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

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var entity = await _context.Set<PermitRiskAssessment>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PermitRiskAssessment>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitRiskAssessment>().Count(e => e.PermitRiskAssessmentId == key) > 0;
        }
    }
}