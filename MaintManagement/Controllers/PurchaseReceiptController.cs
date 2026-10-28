using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class PurchaseReceiptController : ODataController
    {
        private readonly CmmsContext _context;

        public PurchaseReceiptController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PurchaseReceipt> Get()
        {
            return _context.Set<PurchaseReceipt>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var purchaseReceipt = await _context.Set<PurchaseReceipt>().FindAsync(key);
            if (purchaseReceipt == null)
            {
                return NotFound();
            }
            return Ok(purchaseReceipt);
        }

        public async Task<IActionResult> Post([FromBody]PurchaseReceipt purchaseReceipt)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            _context.Set<PurchaseReceipt>().Add(purchaseReceipt);
            await _context.SaveChangesAsync();
            return Created(purchaseReceipt);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] PurchaseReceipt purchaseReceipt)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (key != purchaseReceipt.PurchaseReceiptId)
            {
                return BadRequest();
            }
            _context.Entry(purchaseReceipt).State = EntityState.Modified;
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
            return Updated(purchaseReceipt);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<PurchaseReceipt> patch)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var purchaseReceipt = await _context.Set<PurchaseReceipt>().FindAsync(key);
            if (purchaseReceipt == null)
            {
                return NotFound();
            }
            patch.Patch(purchaseReceipt);
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
            return Updated(purchaseReceipt);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var purchaseReceipt = await _context.Set<PurchaseReceipt>().FindAsync(key);
            if (purchaseReceipt == null)
            {
                return NotFound();
            }
            _context.Set<PurchaseReceipt>().Remove(purchaseReceipt);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PurchaseReceipt>().Count(e => e.PurchaseReceiptId == key) > 0;
        }
    }
}