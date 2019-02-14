using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppHttp.Model
{
    public class Email
    {
        public int? Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<Recipient> Recipients { get; set; }
        public DateTime Date { get; set; }
    }
}
