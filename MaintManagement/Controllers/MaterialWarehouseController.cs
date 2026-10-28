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
    public class MaterialWarehouseController : ODataController
    {
        private readonly CmmsContext _context;

        public MaterialWarehouseController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var materialWarehouses = await _context.MaterialWarehouses.ToListAsync();
            return Ok(materialWarehouses);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            var materialWarehouse = await _context.MaterialWarehouses.FindAsync(key);
            if (materialWarehouse == null)
            {
                return NotFound();
            }
            return Ok(materialWarehouse);
        }

        public async Task<IActionResult> Post([FromBody] MaterialWarehouse materialWarehouse)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _context.MaterialWarehouses.Add(materialWarehouse);
            await _context.SaveChangesAsync();

            return Created(materialWarehouse);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] MaterialWarehouse materialWarehouse)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (key != materialWarehouse.MaterialWarehouseId)
            {
                return BadRequest();
            }

            _context.Entry(materialWarehouse).State = EntityState.Modified;

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

            return Updated(materialWarehouse);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<MaterialWarehouse> delta)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var materialWarehouse = await _context.MaterialWarehouses.FindAsync(key);
            if (materialWarehouse == null)
            {
                return NotFound();
            }

            delta.Patch(materialWarehouse);

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

            return Updated(materialWarehouse);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            var materialWarehouse = await _context.MaterialWarehouses.FindAsync(key);
            if (materialWarehouse == null)
            {
                return NotFound();
            }

            _context.MaterialWarehouses.Remove(materialWarehouse);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.MaterialWarehouses.Any(e => e.MaterialWarehouseId == key);
        }
    }
}