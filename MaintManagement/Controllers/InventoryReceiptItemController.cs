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
    public class InventoryReceiptItemController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryReceiptItemController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryReceiptItem> Get()
        {
            return _context.Set<InventoryReceiptItem>();
        }

        [EnableQuery]
        public async Task<SingleResult<InventoryReceiptItem>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<InventoryReceiptItem>().Where(inventoryReceiptItem => inventoryReceiptItem.InventoryReceiptItemId == key));
        }

        public async Task<IActionResult> Post([FromBody] InventoryReceiptItem inventoryReceiptItem)
        {
            

            _context.Set<InventoryReceiptItem>().Add(inventoryReceiptItem);
            await _context.SaveChangesAsync();

            return Created(inventoryReceiptItem);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryReceiptItem inventoryReceiptItem)
        {
            

            if (key != inventoryReceiptItem.InventoryReceiptItemId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryReceiptItem).State = EntityState.Modified;

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

            return Updated(inventoryReceiptItem);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryReceiptItem> inventoryReceiptItem)
        {
            

            var entity = await _context.Set<InventoryReceiptItem>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryReceiptItem.Patch(entity);

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
            var inventoryReceiptItem = await _context.Set<InventoryReceiptItem>().FindAsync(key);
            if (inventoryReceiptItem == null)
            {
                return NotFound();
            }

            _context.Set<InventoryReceiptItem>().Remove(inventoryReceiptItem);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<InventoryReceiptItem>().Count(e => e.InventoryReceiptItemId == key) > 0;
        }
    }
}