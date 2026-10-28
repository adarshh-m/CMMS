using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
using System;
using System.Collections.Generic;
 
 
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
 
 

namespace YourNamespace.Controllers
{
    public class MaterialCategoryController : ODataController
    {
        // private CmmsContext db = new CmmsContext();
       
        private readonly CmmsContext db;

        public MaterialCategoryController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<MaterialCategory> Get()
        {
            return db.MaterialCategories;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            MaterialCategory materialCategory = await db.MaterialCategories.FindAsync(key);
            if (materialCategory == null)
            {
                return NotFound();
            }
            return Ok(materialCategory);
        }

        public async Task<IActionResult> Post([FromBody] MaterialCategory materialCategory)
        {
            

            db.MaterialCategories.Add(materialCategory);
            await db.SaveChangesAsync();

            return Created(materialCategory);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] MaterialCategory materialCategory)
        {
            

            if (key != materialCategory.MaterialCategoryId)
            {
                return BadRequest();
            }

            db.Entry(materialCategory).State = EntityState.Modified;

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

            return Updated(materialCategory);
        }

        public async Task<IActionResult> Patch( Guid key, [FromBody] Delta<MaterialCategory> patch)
        {
            

            MaterialCategory materialCategory = await db.MaterialCategories.FindAsync(key);
            if (materialCategory == null)
            {
                return NotFound();
            }

            patch.Patch(materialCategory);

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

            return Updated(materialCategory);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            MaterialCategory materialCategory = await db.MaterialCategories.FindAsync(key);
            if (materialCategory == null)
            {
                return NotFound();
            }

            db.MaterialCategories.Remove(materialCategory);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.MaterialCategories.Any(e => e.MaterialCategoryId == key);
        }
    }
}