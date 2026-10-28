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
    public class ProductionLineController : ODataController
    {
        private readonly CmmsContext _context;

        public ProductionLineController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<ProductionLine> Get()
        {
            return _context.Set<ProductionLine>();
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var entity = await _context.Set<ProductionLine>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        public async Task<IActionResult> Post([FromBody] ProductionLine productionLine)
        {
            

            _context.Set<ProductionLine>().Add(productionLine);
            await _context.SaveChangesAsync();

            return Created(productionLine);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ProductionLine productionLine)
        {
            


           

            if (key != productionLine.ProductionLineId)
            {
                return BadRequest();
            }

            _context.Entry(productionLine).State = EntityState.Modified;

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

            return Updated(productionLine);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ProductionLine> patch)
        {
           

            var entity = await _context.Set<ProductionLine>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            patch.Patch(entity);

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
            var entity = await _context.Set<ProductionLine>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Set<ProductionLine>().Remove(entity);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.Set<ProductionLine>().Count(e => e.ProductionLineId == key) > 0;
        }
    }
}