using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace bai7.Models
{
    public class MyCodeFirstContext : DbContext
    {
        public MyCodeFirstContext() : base("MyCodeFirst")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}