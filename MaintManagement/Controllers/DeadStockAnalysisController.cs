using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 

namespace YourNamespace.Controllers
{
    public class DeadStockAnalysisController : ODataController
    {
        private readonly CmmsContext _context;

        public DeadStockAnalysisController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<DeadStockAnalysis> Get()
        {
            return _context.Set<DeadStockAnalysis>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<DeadStockAnalysis>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] DeadStockAnalysis deadStockAnalysis)
        {
           

            _context.Set<DeadStockAnalysis>().Add(deadStockAnalysis);
            await _context.SaveChangesAsync();

            return Created(deadStockAnalysis);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] DeadStockAnalysis deadStockAnalysis)
        {
           
            if (key != deadStockAnalysis.DeadStockAnalysisId)
            {
                return BadRequest();
            }

            _context.Entry(deadStockAnalysis).State = EntityState.Modified;

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

            return Updated(deadStockAnalysis);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<DeadStockAnalysis> patch)
        {
            
            var entity = await _context.Set<DeadStockAnalysis>().FindAsync(key);
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
            var entity = await _context.Set<DeadStockAnalysis>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<DeadStockAnalysis>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<DeadStockAnalysis>().Any(e => e.DeadStockAnalysisId == key);
        }
    }
}