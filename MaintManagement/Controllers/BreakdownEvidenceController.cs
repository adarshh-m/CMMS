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
    public class BreakdownEvidenceController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownEvidenceController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownEvidence> Get()
        {
            return _context.Set<BreakdownEvidence>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownEvidence>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownEvidence breakdownEvidence)
        {
            
            _context.Set<BreakdownEvidence>().Add(breakdownEvidence);
            await _context.SaveChangesAsync();

            return Created(breakdownEvidence);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] BreakdownEvidence breakdownEvidence)
        {
           

            if (key != breakdownEvidence.EvidenceId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownEvidence).State = EntityState.Modified;

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

            return Updated(breakdownEvidence);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<BreakdownEvidence> patch)
        {
           

            var entity = await _context.Set<BreakdownEvidence>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<BreakdownEvidence>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownEvidence>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownEvidence>().Any(e => e.EvidenceId == key);
        }
    }
}