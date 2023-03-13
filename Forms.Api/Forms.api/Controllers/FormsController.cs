using Forms.api.DB;
using Forms.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Forms.api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FormsController : Controller
    {
        private readonly FormDBContext _dbContext;
        public FormsController(FormDBContext dBContext)
        {
            this._dbContext = dBContext; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForms()
        {
            var forms = await _dbContext.Forms.ToListAsync();
            return Ok(forms);
        }

        [HttpPost]
        public async Task<IActionResult> AddForm([FromBody] FormModel form)
        {
            form.Id =  Guid.NewGuid();
            await _dbContext.Forms.AddAsync(form);
            await _dbContext.SaveChangesAsync();

            return Ok(form);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        

    public async Task<IActionResult> UpdateRecord([FromRoute] Guid id)
    {
        var record = await _dbContext.Forms.FirstOrDefaultAsync(x => x.Id == id);
            if (record == null)
            {
                return NotFound();

            }
            return Ok(record);
    }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRecord([FromRoute] Guid id, FormModel updatedForm)
        {
            FormModel form = await _dbContext.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            form.FirstName = updatedForm.FirstName;
            form.MiddleName = updatedForm.MiddleName;
            form.LastName = updatedForm.LastName;
            form.Email = updatedForm.Email;
            form.Address1 = updatedForm.Address1;
            form.Address2 = updatedForm.Address2;
            form.City = updatedForm.City;
            form.ContactNumber = updatedForm.ContactNumber;
            
            form.Zip = updatedForm.Zip;

            await _dbContext.SaveChangesAsync();

            return Ok(form);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] Guid id)
        {
            var record = await _dbContext.Forms.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _dbContext.Forms.Remove(record);
            await _dbContext.SaveChangesAsync();

            return Ok(record);




        }



    }
}