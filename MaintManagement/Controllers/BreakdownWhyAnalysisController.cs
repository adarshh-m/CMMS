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
    public class BreakdownWhyAnalysisController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownWhyAnalysisController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownWhyAnalysis> Get()
        {
            return _context.Set<BreakdownWhyAnalysis>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownWhyAnalysis>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownWhyAnalysis breakdownWhyAnalysis)
        {
            

            _context.Set<BreakdownWhyAnalysis>().Add(breakdownWhyAnalysis);
            await _context.SaveChangesAsync();

            return Created(breakdownWhyAnalysis);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] BreakdownWhyAnalysis breakdownWhyAnalysis)
        {
            

            if (key != breakdownWhyAnalysis.WhyAnalysisId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownWhyAnalysis).State = EntityState.Modified;

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

            return Updated(breakdownWhyAnalysis);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<BreakdownWhyAnalysis> patch)
        {
           

            var entity = await _context.Set<BreakdownWhyAnalysis>().FindAsync(key);
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
            var entity = await _context.Set<BreakdownWhyAnalysis>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownWhyAnalysis>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownWhyAnalysis>().Count(e => e.WhyAnalysisId == key) > 0;
        }
    }
}