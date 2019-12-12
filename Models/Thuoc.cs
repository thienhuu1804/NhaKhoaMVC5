using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class Thuoc
    {
        [Key]
        public String MaThuoc_ID {get;set;}
        public String TenThuoc {get;set;}
        public String GhiChu {get;set;}
        public int Gia {get;set;}
        public int SoLuong {get;set;}
        public virtual ICollection<ChiTietYeuCau_Thuoc> DanhSachChiTietThuoc { get; set; }
    }
}