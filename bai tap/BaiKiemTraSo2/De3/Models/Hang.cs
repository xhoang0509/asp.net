namespace De3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [Key]
        [StringLength(10)]
        [Required(ErrorMessage ="Mã hàng không được để trống!")]
        public string Mahang { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên hàng không được để trống!")]
        public string Tenhang { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Loại hàng không được để trống!")]
        public string Loai { get; set; }

        public int? Gia { get; set; }
    }
}
