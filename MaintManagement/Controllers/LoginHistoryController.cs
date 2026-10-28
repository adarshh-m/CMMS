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
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace YourNamespace.Controllers
{
    public class LoginHistoryController : ODataController
    {
        //private CmmsContext db = new CmmsContext();

        private readonly CmmsContext db;

        public LoginHistoryController(CmmsContext context)
        {
            db = context;
        }

        [EnableQuery]
        public IQueryable<LoginHistory> Get()
        {
            return db.LoginHistories;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] long key)
        {

            LoginHistory loginHistory = await db.LoginHistories.FindAsync(key);
            if (loginHistory == null)
            {
                return NotFound();
            }
            return Ok(loginHistory);
        }

        public async Task<IActionResult> Post([FromBody] LoginHistory loginHistory)
        {
            

            db.LoginHistories.Add(loginHistory);
            await db.SaveChangesAsync();

            return Created(loginHistory);
        }

        public async Task<IActionResult> Put( long key, [FromBody] LoginHistory update)
        {
            

            if (key != update.LoginHistoryId)
            {
                return BadRequest();
            }

            db.Entry(update).State = EntityState.Modified;

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

            return Updated(update);
        }

        public async Task<IActionResult> Patch( long key, [FromBody] Delta<LoginHistory> patch)
        {
           

            LoginHistory loginHistory = await db.LoginHistories.FindAsync(key);
            if (loginHistory == null)
            {
                return NotFound();
            }

            patch.Patch(loginHistory);

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

            return Updated(loginHistory);
        }

        public async Task<IActionResult> Delete([FromBody] long key)
        {
            LoginHistory loginHistory = await db.LoginHistories.FindAsync(key);
            if (loginHistory == null)
            {
                return NotFound();
            }

            db.LoginHistories.Remove(loginHistory);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(long key)
        {
            return db.LoginHistories.Count(e => e.LoginHistoryId == key) > 0;
        }
    }
}