using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppHttp.Model
{
    public class EmailDataContext : DbContext
    {
        public EmailDataContext(DbContextOptions<EmailDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
    }
}
