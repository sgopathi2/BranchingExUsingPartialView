using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext() : base("EmpContext")
        {

        }
        public DbSet<Emp> Emps { get; set; }
    }
}