using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaKhoaMVC5.Models
{
    public class TaiKhoan
    {
        [Key]
        public String TenTaiKhoan_ID { get; set; }
        public String MatKhau { get; set; }
        public string MaNV_ID { get; set; }

        [ForeignKey("MaNV_ID")]
        public virtual NhanVien NhanVien { get; set; }
    }

}