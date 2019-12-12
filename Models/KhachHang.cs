using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class KhachHang
    {
        [Key]
        public String MaKH_ID{get;set;}
        public String TenKH{get;set;}
        public DateTime NgaySinh {get;set;}

        public virtual ICollection<YeuCau> DanhSachYeuCau { get; set; }

    }
}