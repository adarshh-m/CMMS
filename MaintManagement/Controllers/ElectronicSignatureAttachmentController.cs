using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;

namespace YourNamespace.Controllers
{
    public class ElectronicSignatureAttachmentController : ODataController
    {
        private readonly CmmsContext _context;

        public ElectronicSignatureAttachmentController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ElectronicSignatureAttachment> Get()
        {
            return _context.Set<ElectronicSignatureAttachment>();
        }

        [EnableQuery]
        public async Task<SingleResult<ElectronicSignatureAttachment>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.Set<ElectronicSignatureAttachment>().Where(e => e.ElectronicSignatureAttachmentId == key));
        }

        public async Task<IActionResult> Post([FromBody] ElectronicSignatureAttachment electronicSignatureAttachment)
        {
           

            _context.Set<ElectronicSignatureAttachment>().Add(electronicSignatureAttachment);
            await _context.SaveChangesAsync();

            return Created(electronicSignatureAttachment);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] ElectronicSignatureAttachment electronicSignatureAttachment)
        {
            
            if (key != electronicSignatureAttachment.ElectronicSignatureAttachmentId)
            {
                return BadRequest();
            }

            _context.Entry(electronicSignatureAttachment).State = EntityState.Modified;

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

            return Updated(electronicSignatureAttachment);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ElectronicSignatureAttachment> delta)
        {
            
            var entity = await _context.Set<ElectronicSignatureAttachment>().FindAsync(key);
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
            var electronicSignatureAttachment = await _context.Set<ElectronicSignatureAttachment>().FindAsync(key);
            if (electronicSignatureAttachment == null)
            {
                return NotFound();
            }

            _context.Set<ElectronicSignatureAttachment>().Remove(electronicSignatureAttachment);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ElectronicSignatureAttachment>().Count(e => e.ElectronicSignatureAttachmentId == key) > 0;
        }
    }
}