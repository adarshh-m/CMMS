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
    public class PermitApprovalController : ODataController
    {
        private readonly CmmsContext _context;

        public PermitApprovalController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var permitApprovals = await _context.Set<PermitApproval>().ToListAsync();
            return Ok(permitApprovals);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var permitApproval = await _context.Set<PermitApproval>().FindAsync(key);
            if (permitApproval == null)
            {
                return NotFound();
            }
            return Ok(permitApproval);
        }

        public async Task<IActionResult> Post([FromBody] PermitApproval permitApproval)
        {
           

            _context.Set<PermitApproval>().Add(permitApproval);
            await _context.SaveChangesAsync();

            return Created(permitApproval);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] PermitApproval permitApproval)
        {
            

            if (key != permitApproval.PermitApprovalId)
            {
                return BadRequest();
            }

            _context.Entry(permitApproval).State = EntityState.Modified;

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

            return Updated(permitApproval);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<PermitApproval> patch)
        {
            

            var permitApproval = await _context.Set<PermitApproval>().FindAsync(key);
            if (permitApproval == null)
            {
                return NotFound();
            }

            patch.Patch(permitApproval);

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

            return Updated(permitApproval);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var permitApproval = await _context.Set<PermitApproval>().FindAsync(key);
            if (permitApproval == null)
            {
                return NotFound();
            }

            _context.Set<PermitApproval>().Remove(permitApproval);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<PermitApproval>().Count(e => e.PermitApprovalId == key) > 0;
        }
    }
}