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
    public class MaterialVendorController : ODataController
    {
        private readonly CmmsContext _context;

        public MaterialVendorController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MaterialVendor> Get()
        {
            return _context.Set<MaterialVendor>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var materialVendor = await _context.Set<MaterialVendor>().FindAsync(key);
            if (materialVendor == null)
            {
                return NotFound();
            }
            return Ok(materialVendor);
        }

        public async Task<IActionResult> Post([FromBody]MaterialVendor materialVendor)
        {
           

            _context.Set<MaterialVendor>().Add(materialVendor);
            await _context.SaveChangesAsync();

            return Created(materialVendor);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] MaterialVendor materialVendor)
        {
            

            if (key != materialVendor.MaterialVendorId)
            {
                return BadRequest();
            }

            _context.Entry(materialVendor).State = EntityState.Modified;

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

            return Updated(materialVendor);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<MaterialVendor> patch)
        {
           

            var materialVendor = await _context.Set<MaterialVendor>().FindAsync(key);
            if (materialVendor == null)
            {
                return NotFound();
            }

            patch.Patch(materialVendor);

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

            return Updated(materialVendor);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var materialVendor = await _context.Set<MaterialVendor>().FindAsync(key);
            if (materialVendor == null)
            {
                return NotFound();
            }

            _context.Set<MaterialVendor>().Remove(materialVendor);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<MaterialVendor>().Any(e => e.MaterialVendorId == key);
        }
    }
}