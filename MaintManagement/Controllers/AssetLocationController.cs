using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class AssetLocationController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetLocationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetLocation> Get()
        {
            return _context.Set<AssetLocation>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var assetLocation = await _context.Set<AssetLocation>().FindAsync(key);
            if (assetLocation == null)
            {
                return NotFound();
            }
            return Ok(assetLocation);
        }

        public async Task<IActionResult> Post([FromBody]  AssetLocation assetLocation)
        {
           
            assetLocation.LocationId=Guid.NewGuid();
            _context.Set<AssetLocation>().Add(assetLocation);
            await _context.SaveChangesAsync();

            return Created(assetLocation);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetLocation assetLocation)
        {
            

            if (key != assetLocation.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(assetLocation).State = EntityState.Modified;

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

            return Updated(assetLocation);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetLocation> assetLocation)
        {
            

            var entity = await _context.Set<AssetLocation>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            assetLocation.Patch(entity);

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
            var assetLocation = await _context.Set<AssetLocation>().FindAsync(key);
            if (assetLocation == null)
            {
                return NotFound();
            }

            _context.Set<AssetLocation>().Remove(assetLocation);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetLocation>().Count(e => e.LocationId == key) > 0;
        }
    }
}