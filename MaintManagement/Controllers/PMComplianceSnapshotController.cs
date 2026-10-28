using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PMComplianceSnapshotController : ODataController
    {
        private readonly CmmsContext _context;

        public PMComplianceSnapshotController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PmcomplianceSnapshot> Get()
        {
            return _context.Set<PmcomplianceSnapshot>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get(Guid key)
        {
            var entity = await _context.Set<PmcomplianceSnapshot>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] PmcomplianceSnapshot pMComplianceSnapshot)
        {
            pMComplianceSnapshot.SnapshotId = Guid.NewGuid();
            _context.Set<PmcomplianceSnapshot>().Add(pMComplianceSnapshot);
            await _context.SaveChangesAsync();

            return Created(pMComplianceSnapshot);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PmcomplianceSnapshot pMComplianceSnapshot)
        {
            
            if (key != pMComplianceSnapshot.SnapshotId)
            {
                return BadRequest();
            }

            _context.Entry(pMComplianceSnapshot).State = EntityState.Modified;

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

            return Updated(pMComplianceSnapshot);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PmcomplianceSnapshot> delta)
        {
           
            var entity = await _context.Set<PmcomplianceSnapshot>().FindAsync(key);
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
            var entity = await _context.Set<PmcomplianceSnapshot>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<PmcomplianceSnapshot>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PmcomplianceSnapshot>().Count(e => e.SnapshotId == key) > 0;
        }
    }
}