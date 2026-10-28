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
    public class InventoryTransferController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryTransferController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryTransfer> Get()
        {
            return _context.InventoryTransfers;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var inventoryTransfer = await _context.InventoryTransfers.FindAsync(key);
            if (inventoryTransfer == null)
            {
                return NotFound();
            }
            return Ok(inventoryTransfer);
        }

        public async Task<IActionResult> Post([FromBody] InventoryTransfer inventoryTransfer)
        {
           

            _context.InventoryTransfers.Add(inventoryTransfer);
            await _context.SaveChangesAsync();

            return Created(inventoryTransfer);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryTransfer inventoryTransfer)
        {
           

            if (key != inventoryTransfer.InventoryTransferId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryTransfer).State = EntityState.Modified;

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

            return Updated(inventoryTransfer);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryTransfer> inventoryTransfer)
        {
           

            var entity = await _context.InventoryTransfers.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryTransfer.Patch(entity);

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
            var inventoryTransfer = await _context.InventoryTransfers.FindAsync(key);
            if (inventoryTransfer == null)
            {
                return NotFound();
            }

            _context.InventoryTransfers.Remove(inventoryTransfer);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.InventoryTransfers.Any(e => e.InventoryTransferId == key);
        }
    }
}