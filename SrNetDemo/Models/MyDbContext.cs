using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SrNetDemo.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=SrNetConStr") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LoginCredential> Logins { get; set; }
    }
}