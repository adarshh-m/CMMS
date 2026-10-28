using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 

namespace YourNamespace.Controllers
{
    public class AssetCategoryController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetCategoryController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetCategory> Get()
        {
            return _context.Set<AssetCategory>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var assetCategory = await _context.Set<AssetCategory>().FindAsync(key);
            if (assetCategory == null)
            {
                return NotFound();
            }
            return Ok(assetCategory);
        }

        public async Task<IActionResult> Post([FromBody] AssetCategory assetCategory)
        {
           assetCategory.AssetCategoryId=Guid.NewGuid();
            _context.Set<AssetCategory>().Add(assetCategory);
            await _context.SaveChangesAsync();
            return Created(assetCategory);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetCategory assetCategory)
        {
            
            if (key != assetCategory.AssetCategoryId)
            {
                return BadRequest();
            }
            _context.Entry(assetCategory).State = EntityState.Modified;
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
            return Updated(assetCategory);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetCategory> assetCategory)
        {
            
            var entity = await _context.Set<AssetCategory>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            assetCategory.Patch(entity);
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
            var assetCategory = await _context.Set<AssetCategory>().FindAsync(key);
            if (assetCategory == null)
            {
                return NotFound();
            }
            _context.Set<AssetCategory>().Remove(assetCategory);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetCategory>().Count(e => e.AssetCategoryId == key) > 0;
        }
    }
}