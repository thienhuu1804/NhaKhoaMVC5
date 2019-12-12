using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NhaKhoaMVC5.Models
{
    public class ChiTietYeuCau_DichVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Stt_ID { get; set; }
        public string MaDV_ID { get; set; }
        public string MaYC_ID { get; set; }
        //public int gia { get; set; }
        [ForeignKey("MaDV_ID")]
        public virtual DichVu DichVu { get; set; }

        [ForeignKey("MaYC_ID")]
        public virtual YeuCau YeuCau { get; set; }
    }
}