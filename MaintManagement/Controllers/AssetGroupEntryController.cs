using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class AssetGroupEntryController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetGroupEntryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetGroupEntry> Get()
        {
            return _context.Set<AssetGroupEntry>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var assetGroupEntry = await _context.Set<AssetGroupEntry>().FindAsync(key);
            if (assetGroupEntry == null)
            {
                return NotFound();
            }
            return Ok(assetGroupEntry);
        }

        public async Task<IActionResult> Post([FromBody] AssetGroupEntry assetGroupEntry)
        {
            
            assetGroupEntry.AssetGroupEntryId=Guid.NewGuid();
            _context.Set<AssetGroupEntry>().Add(assetGroupEntry);
            await _context.SaveChangesAsync();

            return Created(assetGroupEntry);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] AssetGroupEntry assetGroupEntry)
        {
            
            if (key != assetGroupEntry.AssetGroupEntryId)
            {
                return BadRequest();
            }

            _context.Entry(assetGroupEntry).State = EntityState.Modified;

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

            return Updated(assetGroupEntry);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetGroupEntry> delta)
        {
           

            var assetGroupEntry = await _context.Set<AssetGroupEntry>().FindAsync(key);
            if (assetGroupEntry == null)
            {
                return NotFound();
            }

            delta.Patch(assetGroupEntry);

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

            return Updated(assetGroupEntry);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var assetGroupEntry = await _context.Set<AssetGroupEntry>().FindAsync(key);
            if (assetGroupEntry == null)
            {
                return NotFound();
            }

            _context.Set<AssetGroupEntry>().Remove(assetGroupEntry);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetGroupEntry>().Count(e => e.AssetGroupEntryId == key) > 0;
        }
    }
}