using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Email> Get()
        {
            return getData();
        }

        [HttpPost]
        public void Post([FromBody] Email value)
        {
            EmailSender.Send(ref value);
            db.Add(value);
            db.SaveChanges();
        }
    }
}
