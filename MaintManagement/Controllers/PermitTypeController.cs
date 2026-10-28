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
    public class PermitTypeController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitTypeController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<PermitType> Get()
        {
            return _context.PermitTypes;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitType = await _context.PermitTypes.FindAsync(key);
            if (permitType == null)
            {
                return NotFound();
            }
            return Ok(permitType);
        }

        public async Task<IActionResult> Post([FromBody] PermitType permitType)
        {
            

            _context.PermitTypes.Add(permitType);
            await _context.SaveChangesAsync();

            return Created(permitType);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitType update)
        {
           

            if (key != update.PermitTypeId)
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

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitType> patch)
        {
            

            var permitType = await _context.PermitTypes.FindAsync(key);
            if (permitType == null)
            {
                return NotFound();
            }

            patch.Patch(permitType);

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

            return Updated(permitType);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitType = await _context.PermitTypes.FindAsync(key);
            if (permitType == null)
            {
                return NotFound();
            }

            _context.PermitTypes.Remove(permitType);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.PermitTypes.Any(e => e.PermitTypeId == key);
        }
    }
}