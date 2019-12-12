using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NhaKhoaMVC5.Models;

namespace NhaKhoaMVC5.ModelView
{
    public class YeuCauDichVuThuoc
    {
        public YeuCau YeuCau { get; set; }
        public ICollection<ChiTietYeuCau_DichVu> DichVu { get; set; }
        public ICollection<ChiTietYeuCau_Thuoc> Thuoc { get; set; }
    }
}