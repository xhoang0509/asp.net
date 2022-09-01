using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace bai12_v3.Models
{
    public partial class QLLuongDB : DbContext
    {
        public QLLuongDB()
            : base("name=QLLuongDB")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Manv)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
