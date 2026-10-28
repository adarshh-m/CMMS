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
    public class AssetHierarchyController : ODataController
    {
        private readonly CmmsContext _context;

        public AssetHierarchyController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<AssetHierarchy> Get()
        {
            return _context.Set<AssetHierarchy>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var assetHierarchy = await _context.Set<AssetHierarchy>().FindAsync(key);
            if (assetHierarchy == null)
            {
                return NotFound();
            }
            return Ok(assetHierarchy);
        }

        public async Task<IActionResult> Post([FromBody] AssetHierarchy assetHierarchy)
        {
           
            assetHierarchy.AssetHierarchyId=Guid.NewGuid();
            _context.Set<AssetHierarchy>().Add(assetHierarchy);
            await _context.SaveChangesAsync();

            return Created(assetHierarchy);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] AssetHierarchy assetHierarchy)
        {
            

            if (key != assetHierarchy.AssetHierarchyId)
            {
                return BadRequest();
            }

            _context.Entry(assetHierarchy).State = EntityState.Modified;

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

            return Updated(assetHierarchy);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<AssetHierarchy> delta)
        {
           

            var assetHierarchy = await _context.Set<AssetHierarchy>().FindAsync(key);
            if (assetHierarchy == null)
            {
                return NotFound();
            }

            delta.Patch(assetHierarchy);

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

            return Updated(assetHierarchy);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var assetHierarchy = await _context.Set<AssetHierarchy>().FindAsync(key);
            if (assetHierarchy == null)
            {
                return NotFound();
            }

            _context.Set<AssetHierarchy>().Remove(assetHierarchy);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<AssetHierarchy>().Count(e => e.AssetHierarchyId == key) > 0;
        }
    }
}