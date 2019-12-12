using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class ChucVu
    {
        //public int Id { get; set; }
        [Key]
        public String MaCV_ID { get; set; }
        public String TenCV { get; set; }

        public virtual ICollection<NhanVien> DanhSachNhanVien { get; set; }
    }

}