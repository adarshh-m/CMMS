using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class StockSnapshotController : ODataController
    {
        private readonly CmmsContext _context;

        public StockSnapshotController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<StockSnapshot> Get()
        {
            return _context.Set<StockSnapshot>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var stockSnapshot = await _context.Set<StockSnapshot>().FindAsync(key);
            if (stockSnapshot == null)
            {
                return NotFound();
            }
            return Ok(stockSnapshot);
        }

        public async Task<IActionResult> Post([FromBody] StockSnapshot stockSnapshot)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<StockSnapshot>().Add(stockSnapshot);
            await _context.SaveChangesAsync();

            return Created(stockSnapshot);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] StockSnapshot stockSnapshot)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != stockSnapshot.StockSnapshotId)
            {
                return BadRequest();
            }

            _context.Entry(stockSnapshot).State = EntityState.Modified;

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

            return Updated(stockSnapshot);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<StockSnapshot> delta)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var stockSnapshot = await _context.Set<StockSnapshot>().FindAsync(key);
            if (stockSnapshot == null)
            {
                return NotFound();
            }

            delta.Patch(stockSnapshot);

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

            return Updated(stockSnapshot);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var stockSnapshot = await _context.Set<StockSnapshot>().FindAsync(key);
            if (stockSnapshot == null)
            {
                return NotFound();
            }

            _context.Set<StockSnapshot>().Remove(stockSnapshot);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<StockSnapshot>().Count(e => e.StockSnapshotId == key) > 0;
        }
    }
}