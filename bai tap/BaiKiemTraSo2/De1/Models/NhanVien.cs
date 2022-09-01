namespace De1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        [Required(ErrorMessage = "Mã nhân viên không được để trống!")]
        public string Manv { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Họ tên không được để trống!")]
        public string Hoten { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phòng không được để trống!")]
        public string Phong { get; set; }

        public double? Luong { get; set; }
    }
}
