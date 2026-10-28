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
    public class InventoryReceiptController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryReceiptController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryReceipt> Get()
        {
            return _context.Set<InventoryReceipt>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<InventoryReceipt>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] InventoryReceipt inventoryReceipt)
        {
            

            _context.Set<InventoryReceipt>().Add(inventoryReceipt);
            await _context.SaveChangesAsync();

            return Created(inventoryReceipt);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryReceipt inventoryReceipt)
        {
            

            if (key != inventoryReceipt.InventoryReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryReceipt).State = EntityState.Modified;

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

            return Updated(inventoryReceipt);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryReceipt> patch)
        {
           

            var entity = await _context.Set<InventoryReceipt>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<InventoryReceipt>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<InventoryReceipt>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryReceipt>().Any(e => e.InventoryReceiptId == key);
        }
    }
}