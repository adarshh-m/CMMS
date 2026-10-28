using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMExecutionController : ODataController
    {
        private readonly CmmsContext _context;

        public PMExecutionController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Pmexecution> Get()
        {
            return _context.Set<Pmexecution>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var pmExecution = await _context.Set<Pmexecution>().FindAsync(key);
            if (pmExecution == null)
            {
                return NotFound();
            }
            return Ok(pmExecution);
        }

        public async Task<IActionResult> Post([FromBody] Pmexecution pmExecution)
        {
            
            _context.Set<Pmexecution>().Add(pmExecution);
            await _context.SaveChangesAsync();

            return Created(pmExecution);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] Pmexecution pmExecution)
        {
            
            if (key != pmExecution.PmexecutionId)
            {
                return BadRequest();
            }

            _context.Entry(pmExecution).State = EntityState.Modified;

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

            return Updated(pmExecution);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Pmexecution> delta)
        {
           
            var pmExecution = await _context.Set<Pmexecution>().FindAsync(key);
            if (pmExecution == null)
            {
                return NotFound();
            }

            delta.Patch(pmExecution);

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

            return Updated(pmExecution);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var pmExecution = await _context.Set<Pmexecution>().FindAsync(key);
            if (pmExecution == null)
            {
                return NotFound();
            }

            _context.Set<Pmexecution>().Remove(pmExecution);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Pmexecution>().Any(e => e.PmexecutionId == key);
        }
    }
}