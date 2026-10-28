using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class GoodsReceiptNoteController : ODataController
    {
        private readonly CmmsContext _context;

        public GoodsReceiptNoteController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<GoodsReceiptNote> Get()
        {
            return _context.Set<GoodsReceiptNote>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<GoodsReceiptNote>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] GoodsReceiptNote goodsReceiptNote)
        {
            
            _context.Set<GoodsReceiptNote>().Add(goodsReceiptNote);
            await _context.SaveChangesAsync();

            return Created(goodsReceiptNote);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] GoodsReceiptNote goodsReceiptNote)
        {
           
            if (key != goodsReceiptNote.ReceiptId)
            {
                return BadRequest();
            }

            _context.Entry(goodsReceiptNote).State = EntityState.Modified;

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

            return Updated(goodsReceiptNote);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<GoodsReceiptNote> delta)
        {
            
            var entity = await _context.Set<GoodsReceiptNote>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            delta.Patch(entity);

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
            var entity = await _context.Set<GoodsReceiptNote>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<GoodsReceiptNote>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<GoodsReceiptNote>().Count(e => e.ReceiptId == key) > 0;
        }
    }
}