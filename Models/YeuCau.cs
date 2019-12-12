using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaKhoaMVC5.Models
{
    public class YeuCau
    {
        [Key]
        public string MaYC_ID {get;set;}
        //public string maTiepTan {get;set;}
        public string MaNhaSi {get;set;}
        public string MaKH {get;set;}

        //[ForeignKey("maTiepTan")]
        //public virtual NhanVien tiepTan { get; set; }

        [ForeignKey("MaNhaSi")]
        public virtual NhanVien NhaSi { get; set; }

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
        public virtual ICollection<ChiTietYeuCau_DichVu> DanhSachDichVu {get;set;}
        public virtual ICollection<ChiTietYeuCau_Thuoc> DanhSachThuoc {get;set;}
        public DateTime NgayYC {get;set;}
        public int TongTien {get;set;}

    }
}