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
    public class LocalizationController : ODataController
    {
        private readonly CmmsContext _context;

        public LocalizationController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Localization> Get()
        {
            return _context.Set<Localization>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var localization = await _context.Set<Localization>().FindAsync(key);
            if (localization == null)
            {
                return NotFound();
            }
            return Ok(localization);
        }

        public async Task<IActionResult> Post([FromBody]Localization localization)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<Localization>().Add(localization);
            await _context.SaveChangesAsync();

            return Created(localization);
        }

        public async Task<IActionResult> Put( Guid key,[FromBody] Localization update)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != update.LocalizationId)
            {
                return BadRequest();
            }

            var localization = await _context.Set<Localization>().FindAsync(key);
            if (localization == null)
            {
                return NotFound();
            }

            _context.Entry(localization).CurrentValues.SetValues(update);
            await _context.SaveChangesAsync();

            return Updated(update);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Localization> delta)
        {
            //ModelState.Remove("Tenant");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var localization = await _context.Set<Localization>().FindAsync(key);
            if (localization == null)
            {
                return NotFound();
            }

            delta.Patch(localization);
            await _context.SaveChangesAsync();

            return Updated(localization);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var localization = await _context.Set<Localization>().FindAsync(key);
            if (localization == null)
            {
                return NotFound();
            }

            _context.Set<Localization>().Remove(localization);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Localization>().Any(e => e.LocalizationId == key);
        }
    }
}