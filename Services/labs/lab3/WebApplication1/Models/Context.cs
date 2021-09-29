using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=DBContext") { }
        public DbSet<Student> Students { get; set; }
    }
}