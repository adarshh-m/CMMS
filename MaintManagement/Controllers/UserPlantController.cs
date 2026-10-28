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
    public class UserPlantController : ODataController
    {
        private readonly CmmsContext _context;

        public UserPlantController(CmmsContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IQueryable<UserPlant> Get()
        {
            return _context.UserPlants;
        }

        [EnableQuery]
        public async Task<SingleResult<UserPlant>> Get([FromBody] Guid key)
        {
            return SingleResult.Create(_context.UserPlants.Where(userPlant => userPlant.UserPlantId == key));
        }

        public async Task<IActionResult> Post([FromBody]UserPlant userPlant)
        {
            userPlant.UserPlantId = Guid.NewGuid();
            _context.UserPlants.Add(userPlant);
            await _context.SaveChangesAsync();

            return Created(userPlant);
        }

        public async Task<IActionResult> Put( Guid key,[FromBody] UserPlant userPlant)
        {
            
            if (key != userPlant.UserPlantId)
            {
                return BadRequest();
            }

            _context.Entry(userPlant).State = EntityState.Modified;

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

            return Updated(userPlant);
        }

        public async Task<IActionResult> Patch(Guid key,[FromBody] Delta<UserPlant> patch)
        {

            UserPlant userPlant = await _context.UserPlants.FindAsync(key);
            if (userPlant == null)
            {
                return NotFound();
            }

            patch.Patch(userPlant);

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

            return Updated(userPlant);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            UserPlant userPlant = await _context.UserPlants.FindAsync(key);
            if (userPlant == null)
            {
                return NotFound();
            }

            _context.UserPlants.Remove(userPlant);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return _context.UserPlants.Count(e => e.UserPlantId == key) > 0;
        }
    }
}