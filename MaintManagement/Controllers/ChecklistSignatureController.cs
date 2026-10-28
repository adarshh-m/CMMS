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
    public class ChecklistSignatureController : ODataController
    {
        private readonly CmmsContext _context;

        public ChecklistSignatureController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ChecklistSignature> Get()
        {
            return _context.Set<ChecklistSignature>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ChecklistSignature>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistSignature checklistSignature)
        {
           
            _context.Set<ChecklistSignature>().Add(checklistSignature);
            await _context.SaveChangesAsync();

            return Created(checklistSignature);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistSignature checklistSignature)
        {
            
            if (key != checklistSignature.ChecklistSignatureId)
            {
                return BadRequest();
            }

            _context.Entry(checklistSignature).State = EntityState.Modified;

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

            return Updated(checklistSignature);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistSignature> delta)
        {
            

            var entity = await _context.Set<ChecklistSignature>().FindAsync(key);
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
            var entity = await _context.Set<ChecklistSignature>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<ChecklistSignature>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ChecklistSignature>().Any(e => e.ChecklistSignatureId == key);
        }
    }
}