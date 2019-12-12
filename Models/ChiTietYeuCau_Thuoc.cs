using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class ChiTietYeuCau_Thuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Stt { get; set; }
        public string MaYC_ID { get; set; }
        public String MaThuoc_ID {get;set;}
        //public String tenThuoc {get;set;}
        //public String ghiChu {get;set;}
        //public int gia {get;set;}
        public int SoLuong {get;set;}

        [ForeignKey("MaThuoc_ID")]
        public virtual Thuoc Thuoc { get; set; }

        [ForeignKey("MaYC_ID")]
        public virtual YeuCau YeuCau { get; set; }
    }
}