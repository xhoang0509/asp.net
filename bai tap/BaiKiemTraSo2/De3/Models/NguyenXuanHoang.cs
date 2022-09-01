using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De3.Models
{
    public partial class NguyenXuanHoang : DbContext
    {
        public NguyenXuanHoang()
            : base("name=NguyenXuanHoang")
        {
        }

        public virtual DbSet<Hang> Hangs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .Property(e => e.Mahang)
                .IsFixedLength();
        }
    }
}
