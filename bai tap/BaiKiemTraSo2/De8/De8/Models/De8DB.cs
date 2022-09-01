using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De8.Models
{
    public partial class De8DB : DbContext
    {
        public De8DB()
            : base("name=De8DB")
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenhNhan>()
                .Property(e => e.Mabn)
                .IsFixedLength();
        }
    }
}
