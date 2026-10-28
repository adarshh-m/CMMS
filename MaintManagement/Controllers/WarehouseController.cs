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
    public class WarehouseController : ODataController
    {
        private readonly CmmsContext db;

        public WarehouseController(CmmsContext context)
        {
            db = context;
        }
        // GET: odata/Warehouse
        [EnableQuery]
        public IQueryable<Warehouse> Get()
        {
            return db.Warehouses;
        }

        // GET: odata/Warehouse(5)
        [EnableQuery]
        public SingleResult<Warehouse> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.Warehouses.Where(warehouse => warehouse.WarehouseId == key));
        }

        // POST: odata/Warehouse
        public async Task<IActionResult> Post([FromBody] Warehouse warehouse)
        {
           
            warehouse.WarehouseId = Guid.NewGuid();
            db.Warehouses.Add(warehouse);
            await db.SaveChangesAsync();

            return Created(warehouse);
        }

        // PUT: odata/Warehouse(5)
        public async Task<IActionResult> Put(Guid key, [FromBody] Warehouse warehouse)
        {
            

            if (key != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            db.Entry(warehouse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(warehouse);
        }

        // PATCH: odata/Warehouse(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<Warehouse> delta)
        {
           
            Warehouse warehouse = await db.Warehouses.FindAsync(key);
            if (warehouse == null)
            {
                return NotFound();
            }

            delta.Patch(warehouse);

            try
            {
                await db.SaveChangesAsync();
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

            return Updated(warehouse);
        }

        // DELETE: odata/Warehouse(5)
        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            Warehouse warehouse = await db.Warehouses.FindAsync(key);
            if (warehouse == null)
            {
                return NotFound();
            }

            db.Warehouses.Remove(warehouse);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.Warehouses.Count(e => e.WarehouseId == key) > 0;
        }
    }
}