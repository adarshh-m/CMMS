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
    public class UOMController : ODataController
    {
        private readonly CmmsContext _context;

        public UOMController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public SingleResult<Uom> Get([FromBody] string key)
        {
            return SingleResult.Create(_context.Uoms.Where(uom => uom.Uomname == key));
        }

        public async Task<IActionResult> Post([FromBody]Uom uom)
        {

            _context.Uoms.Add(uom);
            await _context.SaveChangesAsync();

            return Created(uom);
        }

        public async Task<IActionResult> Put(string key,[FromBody] Uom update)
        {
            if (key != update.Uomcode)
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

        public async Task<IActionResult> Patch(string key,[FromBody] Delta<Uom> patch)
        {
            Uom uom = await _context.Uoms.FindAsync(key);
            if (uom == null)
            {
                return NotFound();
            }

            patch.Patch(uom);

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

            return Updated(uom);
        }

        public async Task<IActionResult> Delete([FromBody] string key)
        {
            Uom uom = await _context.Uoms.FindAsync(key);
            if (uom == null)
            {
                return NotFound();
            }

            _context.Uoms.Remove(uom);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(string key)
        {
            return _context.Uoms.Count(e => e.Uomcode == key) > 0;
        }
    }
}