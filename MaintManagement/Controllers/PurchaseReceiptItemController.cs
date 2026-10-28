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
    public class PurchaseReceiptItemController : ODataController
    {
        private readonly CmmsContext _context;

        public PurchaseReceiptItemController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PurchaseReceiptItem> Get()
        {
            return _context.Set<PurchaseReceiptItem>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var purchaseReceiptItem = await _context.Set<PurchaseReceiptItem>().FindAsync(key);
            if (purchaseReceiptItem == null)
            {
                return NotFound();
            }
            return Ok(purchaseReceiptItem);
        }

        public async Task<IActionResult> Post([FromBody] PurchaseReceiptItem purchaseReceiptItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.Set<PurchaseReceiptItem>().Add(purchaseReceiptItem);
            await _context.SaveChangesAsync();

            return Created(purchaseReceiptItem);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PurchaseReceiptItem purchaseReceiptItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != purchaseReceiptItem.PurchaseReceiptItemId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseReceiptItem).State = EntityState.Modified;

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

            return Updated(purchaseReceiptItem);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PurchaseReceiptItem> patch)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var purchaseReceiptItem = await _context.Set<PurchaseReceiptItem>().FindAsync(key);
            if (purchaseReceiptItem == null)
            {
                return NotFound();
            }

            patch.Patch(purchaseReceiptItem);

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

            return Updated(purchaseReceiptItem);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var purchaseReceiptItem = await _context.Set<PurchaseReceiptItem>().FindAsync(key);
            if (purchaseReceiptItem == null)
            {
                return NotFound();
            }

            _context.Set<PurchaseReceiptItem>().Remove(purchaseReceiptItem);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PurchaseReceiptItem>().Count(e => e.PurchaseReceiptItemId == key) > 0;
        }
    }
}