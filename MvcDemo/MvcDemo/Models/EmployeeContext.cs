using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BL;

namespace MvcDemo.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<BL.Department> Departments { get; set; }
        public DbSet<BL.Employee> Employees { get; set; }
    }
}