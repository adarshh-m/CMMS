using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class StorageLocationController : ODataController
    {
        private readonly CmmsContext _context;

        public StorageLocationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<StorageLocation> Get()
        {
            return _context.Set<StorageLocation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<StorageLocation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] StorageLocation storageLocation)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<StorageLocation>().Add(storageLocation);
            await _context.SaveChangesAsync();

            return Created(storageLocation);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] StorageLocation storageLocation)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != storageLocation.StorageLocationId)
            {
                return BadRequest();
            }

            _context.Entry(storageLocation).State = EntityState.Modified;

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

            return Updated(storageLocation);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<StorageLocation> storageLocation)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var entity = await _context.Set<StorageLocation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            storageLocation.Patch(entity);

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
            var storageLocation = await _context.Set<StorageLocation>().FindAsync(key);
            if (storageLocation == null)
            {
                return NotFound();
            }

            _context.Set<StorageLocation>().Remove(storageLocation);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<StorageLocation>().Any(e => e.StorageLocationId == key);
        }
    }
}