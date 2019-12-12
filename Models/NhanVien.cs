using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class NhanVien
    {
        [Key]
        public String MaNV_ID {get;set;}
        public String MaCV {get;set;}
        public String TenNV {get;set;}
        public DateTime NgaySinh {get;set;}
        public String Sdt {get;set;}

        [ForeignKey("MaCV")]
        public virtual ChucVu ChucVu { get; set; }

        public virtual ICollection<YeuCau> DanhSachYeuCau { get; set; }
    }
}