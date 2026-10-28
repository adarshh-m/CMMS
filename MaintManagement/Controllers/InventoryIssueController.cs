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
    public class InventoryIssueController : ODataController
    {
        private readonly CmmsContext _context;

        public InventoryIssueController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<InventoryIssue> Get()
        {
            return _context.InventoryIssues;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var inventoryIssue = await _context.InventoryIssues.FindAsync(key);
            if (inventoryIssue == null)
            {
                return NotFound();
            }
            return Ok(inventoryIssue);
        }

        public async Task<IActionResult> Post([FromBody] InventoryIssue inventoryIssue)
        {
            

            _context.InventoryIssues.Add(inventoryIssue);
            await _context.SaveChangesAsync();

            return Created(inventoryIssue);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] InventoryIssue inventoryIssue)
        {
           

            if (key != inventoryIssue.InventoryIssueId)
            {
                return BadRequest();
            }

            _context.Entry(inventoryIssue).State = EntityState.Modified;

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

            return Updated(inventoryIssue);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<InventoryIssue> inventoryIssue)
        {
            

            var entity = await _context.InventoryIssues.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            inventoryIssue.Patch(entity);

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
            var inventoryIssue = await _context.InventoryIssues.FindAsync(key);
            if (inventoryIssue == null)
            {
                return NotFound();
            }

            _context.InventoryIssues.Remove(inventoryIssue);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.InventoryIssues.Any(e => e.InventoryIssueId == key);
        }
    }
}