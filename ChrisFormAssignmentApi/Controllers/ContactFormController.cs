using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChrisFormAssignmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> SaveContactInfoToFile(ContactForm form)
        {
            string text = "Contact Form Submission Results\n\n";
            text += $"First Name: {form.FirstName}\n";
            text += $"Last Name: {form.LastName}\n";
            text += $"Email: {form.Email}\n";
            text += $"Message: {form.Message}";

            var filePath = "ContactFormResults.txt";

            await System.IO.File.WriteAllTextAsync(filePath, text);

            return Ok();
        }
    }
}
