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
    public class MaterialCostLedgerController : ODataController
    {
        private readonly CmmsContext _context;

        public MaterialCostLedgerController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<MaterialCostLedger> Get()
        {
            return _context.Set<MaterialCostLedger>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<MaterialCostLedger>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] MaterialCostLedger materialCostLedger)
        {
            

            _context.Set<MaterialCostLedger>().Add(materialCostLedger);
            await _context.SaveChangesAsync();

            return Created(materialCostLedger);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] MaterialCostLedger materialCostLedger)
        {
           

            if (key != materialCostLedger.MaterialCostLedgerId)
            {
                return BadRequest();
            }

            _context.Entry(materialCostLedger).State = EntityState.Modified;

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

            return Updated(materialCostLedger);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<MaterialCostLedger> materialCostLedger)
        {
            

            var entity = await _context.Set<MaterialCostLedger>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            materialCostLedger.Patch(entity);

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
            var materialCostLedger = await _context.Set<MaterialCostLedger>().FindAsync(key);
            if (materialCostLedger == null)
            {
                return NotFound();
            }

            _context.Set<MaterialCostLedger>().Remove(materialCostLedger);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<MaterialCostLedger>().Find(key) != null;
        }
    }
}