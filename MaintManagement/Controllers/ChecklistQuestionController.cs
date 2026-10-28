using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using MaintManagement.Models;
namespace YourNamespace.Controllers
{
    public class ChecklistQuestionController : ODataController
    {
        private readonly CmmsContext db;

        public ChecklistQuestionController(CmmsContext context)
        {
            db = context;
        }
        [EnableQuery]
        public IQueryable<ChecklistQuestion> Get()
        {
            return db.ChecklistQuestions;
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromBody] Guid key)
        {
            ChecklistQuestion checklistQuestion = await db.ChecklistQuestions.FindAsync(key);
            if (checklistQuestion == null)
            {
                return NotFound();
            }
            return Ok(checklistQuestion);
        }

        public async Task<IActionResult> Post([FromBody] ChecklistQuestion checklistQuestion)
        {
            

            db.ChecklistQuestions.Add(checklistQuestion);
            await db.SaveChangesAsync();

            return Created(checklistQuestion);
        }

        public async Task<IActionResult> Put(Guid key, [FromBody] ChecklistQuestion checklistQuestion)
        {
           

            if (key != checklistQuestion.ChecklistQuestionId)
            {
                return BadRequest();
            }

            db.Entry(checklistQuestion).State = EntityState.Modified;

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

            return Updated(checklistQuestion);
        }

        public async Task<IActionResult> Patch(Guid key, [FromBody] Delta<ChecklistQuestion> delta)
        {
            

            ChecklistQuestion checklistQuestion = await db.ChecklistQuestions.FindAsync(key);
            if (checklistQuestion == null)
            {
                return NotFound();
            }

            delta.Patch(checklistQuestion);

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

            return Updated(checklistQuestion);
        }

        public async Task<IActionResult> Delete([FromBody] Guid key)
        {
            ChecklistQuestion checklistQuestion = await db.ChecklistQuestions.FindAsync(key);
            if (checklistQuestion == null)
            {
                return NotFound();
            }

            db.ChecklistQuestions.Remove(checklistQuestion);
            await db.SaveChangesAsync();

            return StatusCode(204);
        }

        private bool Exists(Guid key)
        {
            return db.ChecklistQuestions.Count(e => e.ChecklistQuestionId == key) > 0;
        }
    }
}