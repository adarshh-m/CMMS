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
    public class VendorController : ODataController
    {
        private readonly CmmsContext _context;

        public VendorController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Vendor> Get()
        {
            return _context.Vendors;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] string key)
        {
            var vendor = await _context.Vendors.FindAsync(key);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        public async Task<IActionResult> Post(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return Created(vendor);
        }

        public async Task<IActionResult> Put([FromBody] string key, Vendor update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.VendorCode)
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

        public async Task<IActionResult> Patch([FromBody] string key, Delta<Vendor> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendors.FindAsync(key);
            if (vendor == null)
            {
                return NotFound();
            }

            patch.Patch(vendor);

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

            return Updated(vendor);
        }

        public async Task<IActionResult> Delete([FromBody] string key)
        {
            var vendor = await _context.Vendors.FindAsync(key);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(string key)
        {
            return _context.Vendors.Any(e => e.VendorCode == key);
        }
    }
}