using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De2.Models
{
    public partial class NguyenXuanHoang : DbContext
    {
        public NguyenXuanHoang()
            : base("name=NguyenXuanHoang")
        {
        }

        public virtual DbSet<HoSo> HoSoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoSo>()
                .Property(e => e.Mahs)
                .IsFixedLength();
        }
    }
}
