using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppHttp.Model
{
    public class Recipient
    {
        public int? ID { get; set; }
        public string RecipientEmail { get; set; }
        public string Result { get; set; }
        public string FailedMessage { get; set; }
        public int? EmailID { get; set; }
    }
}
