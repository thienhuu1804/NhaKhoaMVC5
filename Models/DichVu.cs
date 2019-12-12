using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class DichVu
    {
        [Key]
        public string MaDV_ID { get; set; }
        public string TenDV { get; set; }
        public int Gia { get; set; }

        public virtual ICollection<ChiTietYeuCau_DichVu> DanhSachChiTietDichVu { get; set; }
    }
}