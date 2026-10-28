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
    public class IntegrationCredentialController : ODataController
    {
        //private CmmsContext db = new CmmsContext();

        private readonly CmmsContext db;

        public IntegrationCredentialController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<IntegrationCredential> Get()
        {
            return db.IntegrationCredentials;
        }

        [EnableQuery]
        public async Task<SingleResult<IntegrationCredential>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(db.IntegrationCredentials.Where(integrationCredential => integrationCredential.IntegrationCredentialId == key));
        }

        public async Task<IActionResult> Post([FromBody] IntegrationCredential integrationCredential)
        {
            

            db.IntegrationCredentials.Add(integrationCredential);
            await db.SaveChangesAsync();

            return Created(integrationCredential);
        }

        public async Task<IActionResult> Put( Guid key, [FromBody] IntegrationCredential integrationCredential)
        {
            

            if (key != integrationCredential.IntegrationCredentialId)
            {
                return BadRequest();
            }

            db.Entry(integrationCredential).State = EntityState.Modified;

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

            return Updated(integrationCredential);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<IntegrationCredential> integrationCredential)
        {
            

            var entity = await db.IntegrationCredentials.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            integrationCredential.Patch(entity);

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

            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            IntegrationCredential integrationCredential = await db.IntegrationCredentials.FindAsync(key);
            if (integrationCredential == null)
            {
                return NotFound();
            }

            db.IntegrationCredentials.Remove(integrationCredential);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.IntegrationCredentials.Count(e => e.IntegrationCredentialId == key) > 0;
        }
    }
}