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
    public class MenuController : ODataController
    {
        private readonly CmmsContext _context;

        public MenuController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<Menu> Get()
        {
            return _context.Set<Menu>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var menu = await _context.Set<Menu>().FindAsync(key);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        public async Task<IActionResult> Post([FromBody] Menu menu)
        {
            

            _context.Set<Menu>().Add(menu);
            await _context.SaveChangesAsync();

            return Created(menu);
        }

        public async Task<IActionResult> Put([FromBody] Guid key, Menu update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != update.MenuId)
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

        public async Task<IActionResult> Patch([FromBody] Guid key, Delta<Menu> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Set<Menu>().FindAsync(key);
            if (menu == null)
            {
                return NotFound();
            }

            patch.Patch(menu);

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

            return Updated(menu);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var menu = await _context.Set<Menu>().FindAsync(key);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Set<Menu>().Remove(menu);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<Menu>().Count(e => e.MenuId == key) > 0;
        }
    }
}