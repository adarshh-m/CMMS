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
    public class BreakdownInvestigationController : ODataController
    {
        private readonly CmmsContext _context;

        public BreakdownInvestigationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<BreakdownInvestigation> Get()
        {
            return _context.Set<BreakdownInvestigation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<BreakdownInvestigation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] BreakdownInvestigation breakdownInvestigation)
        {
            

            _context.Set<BreakdownInvestigation>().Add(breakdownInvestigation);
            await _context.SaveChangesAsync();

            return Created(breakdownInvestigation);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] BreakdownInvestigation breakdownInvestigation)
        {
            

            if (key != breakdownInvestigation.InvestigationId)
            {
                return BadRequest();
            }

            _context.Entry(breakdownInvestigation).State = EntityState.Modified;

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

            return Updated(breakdownInvestigation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<BreakdownInvestigation> patch)
        {
           

            var entity = await _context.Set<BreakdownInvestigation>().FindAsync(key);
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
            var entity = await _context.Set<BreakdownInvestigation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<BreakdownInvestigation>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<BreakdownInvestigation>().Find(key) != null;
        }
    }
}