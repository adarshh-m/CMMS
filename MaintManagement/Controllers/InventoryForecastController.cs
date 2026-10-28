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
    public class InventoryForecastController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryForecastController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryForecast> Get()
        {
            return _context.InventoryForecasts;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var inventoryForecast = await _context.InventoryForecasts.FindAsync(key);
            if (inventoryForecast == null)
            {
                return NotFound();
            }
            return Ok(inventoryForecast);
        }

        public async Task<IActionResult> Post([FromBody] InventoryForecast inventoryForecast)
        {
            

            _context.InventoryForecasts.Add(inventoryForecast);
            await _context.SaveChangesAsync();

            return Created(inventoryForecast);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] InventoryForecast inventoryForecast)
        {
            

            if (key != inventoryForecast.InventoryForecastId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryForecast).State = EntityState.Modified;

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

            return Updated(inventoryForecast);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryForecast> delta)
        {
            

            var inventoryForecast = await _context.InventoryForecasts.FindAsync(key);
            if (inventoryForecast == null)
            {
                return NotFound();
            }

            delta.Patch(inventoryForecast);

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

            return Updated(inventoryForecast);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var inventoryForecast = await _context.InventoryForecasts.FindAsync(key);
            if (inventoryForecast == null)
            {
                return NotFound();
            }

            _context.InventoryForecasts.Remove(inventoryForecast);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.InventoryForecasts.Any(e => e.InventoryForecastId == key);
        }
    }
}