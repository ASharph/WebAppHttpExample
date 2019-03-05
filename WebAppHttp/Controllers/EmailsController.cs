using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppHttp.Model;

namespace WebAppHttp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private EmailDataContext db;

        public EmailsController(EmailDataContext context)
        {
            db = context;
        }
        private List<Email> getData()
        {

            List<Email> Le = new List<Email>();
            Le = db.Emails.ToList();

            List<Recipient> lr = db.Recipients.ToList();

            return Le;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> Get()
        {
            return await db.Emails.Include(p => p.Recipients).ToListAsync();
        }

        [HttpPost]
        public async Task PostTodoItem(Email value)
        {
            EmailSender.Send(ref value);
            db.Emails.Add(value);
            await db.SaveChangesAsync();
        }
    }
}
