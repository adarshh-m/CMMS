using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

 
 

namespace YourNamespace.Controllers
{
    public class AssetTypeController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetTypeController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetType> Get()
        {
            return _context.Set<AssetType>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get( Guid key)
        {
            var assetType = await _context.Set<AssetType>().FindAsync(key);
            if (assetType == null)
            {
                return NotFound();
            }
            return Ok(assetType);
        }

        //public async Task<IActionResult> Post([FromBody] AssetType assetType)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    assetType.Tenant = null!;
        //    _context.Set<AssetType>().Add(assetType);
        //    await _context.SaveChangesAsync();

        //    return Created(assetType);
        //}
        public async Task<IActionResult> Post([FromBody] AssetType assetType)
        {
            
            assetType.AssetTypeId = Guid.NewGuid();
            assetType.Tenant = null!;

            _context.Set<AssetType>().Add(assetType);
            await _context.SaveChangesAsync();

            return Created(assetType);
        }
        public async Task<IActionResult> Put( Guid key, [FromBody] AssetType assetType)
        {
            

            if (key != assetType.AssetTypeId)
            {
                return BadRequest();
            }

            _context.Entry(assetType).State = EntityState.Modified;

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

            return Updated(assetType);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetType> assetType)
        {
            
            var entity = await _context.Set<AssetType>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            assetType.Patch(entity);

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
            var assetType = await _context.Set<AssetType>().FindAsync(key);
            if (assetType == null)
            {
                return NotFound();
            }

            _context.Set<AssetType>().Remove(assetType);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        

        private bool Exists(Guid key)
        {
            return _context.Set<AssetType>().Count(e => e.AssetTypeId == key) > 0;
        }
    }
}