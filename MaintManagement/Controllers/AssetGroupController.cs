using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class AssetGroupController : ODataController
    {
        private readonly CmmsContext db;

        public AssetGroupController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<AssetGroup> Get()
        {
            return db.AssetGroups;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            AssetGroup assetGroup = await db.AssetGroups.FindAsync(key);
            if (assetGroup == null)
            {
                return NotFound();
            }
            return Ok(assetGroup);
        }

        public async Task<IActionResult> Post([FromBody] AssetGroup assetGroup)
        {
            
            assetGroup.AssetGroupId=Guid.NewGuid();
            db.AssetGroups.Add(assetGroup);
            await db.SaveChangesAsync();

            return Created(assetGroup);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetGroup assetGroup)
        {
            
            if (key != assetGroup.AssetGroupId)
            {
                return BadRequest();
            }

            db.Entry(assetGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(assetGroup);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetGroup> delta)
        {
            

            AssetGroup assetGroup = await db.AssetGroups.FindAsync(key);
            if (assetGroup == null)
            {
                return NotFound();
            }

            delta.Patch(assetGroup);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(assetGroup);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            AssetGroup assetGroup = await db.AssetGroups.FindAsync(key);
            if (assetGroup == null)
            {
                return NotFound();
            }

            db.AssetGroups.Remove(assetGroup);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        

        private bool Exists(Guid key)
        {
            return db.AssetGroups.Count(e => e.AssetGroupId == key) > 0;
        }
    }
}