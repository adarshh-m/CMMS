using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class SpareRequestController : ODataController
    {
        private readonly CmmsContext _context;

        public SpareRequestController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<SpareRequest> Get()
        {
            return _context.Set<SpareRequest>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var spareRequest = await _context.Set<SpareRequest>().FindAsync(key);
            if (spareRequest == null)
            {
                return NotFound();
            }
            return Ok(spareRequest);
        }

        public async Task<IActionResult> Post([FromBody] SpareRequest spareRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<SpareRequest>().Add(spareRequest);
            await _context.SaveChangesAsync();

            return Created(spareRequest);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] SpareRequest spareRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != spareRequest.SpareRequestId)
            {
                return BadRequest();
            }

            _context.Entry(spareRequest).State = EntityState.Modified;

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

            return Updated(spareRequest);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<SpareRequest> spareRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var entity = await _context.Set<SpareRequest>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            spareRequest.Patch(entity);

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
            var spareRequest = await _context.Set<SpareRequest>().FindAsync(key);
            if (spareRequest == null)
            {
                return NotFound();
            }

            _context.Set<SpareRequest>().Remove(spareRequest);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<SpareRequest>().Count(e => e.SpareRequestId == key) > 0;
        }
    }
}