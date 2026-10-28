using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

 
 
 

//namespace MaintManagement.

    public class AssetController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Asset> Get()
        {
            return _context.Set<Asset>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var asset = await _context.Set<Asset>().FindAsync(key);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        public async Task<IActionResult> Post([FromBody] Asset asset)
        {

        asset.AssetId = Guid.NewGuid();
        _context.Set<Asset>().Add(asset);
            await _context.SaveChangesAsync();

            return Created(asset);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] Asset update)
        {
            

            if (key != update.AssetId)
            {
                return BadRequest();
            }

            _context.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<Asset> patch)
        {
           

            var asset = await _context.Set<Asset>().FindAsync(key);
            if (asset == null)
            {
                return NotFound();
            }

            patch.Patch(asset);

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

            return Updated(asset);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var asset = await _context.Set<Asset>().FindAsync(key);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Set<Asset>().Remove(asset);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Asset>().Count(e => e.AssetId == key) > 0;
        }
    }
