using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace WebAPI2Demo.TheData
{
    public partial class TwilioContext : DbContext
    {
        public DbSet<TwilioSMS> Enrollments { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}