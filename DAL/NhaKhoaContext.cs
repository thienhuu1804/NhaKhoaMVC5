using System.Data.Entity;
using NhaKhoaMVC5.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NhaKhoaMVC5.DAL
{
    public class NhaKhoaContext : DbContext
    {
        public NhaKhoaContext() : base("NhaKhoaContext")
        {
        }
            public DbSet<KhachHang> KhachHangTB { get; set; }
            public DbSet<DichVu> DichVuTB {get;set;}
            public DbSet<ChucVu> ChucVuTB {get;set;}
            public DbSet<YeuCau> YeuCauTB {get;set;}
            public DbSet<ChiTietYeuCau_Thuoc> ChiTietYeuCauThuoc { get; set; }
            public DbSet<ChiTietYeuCau_DichVu> ChiTietYeuCauDichVu { get; set; }
            public DbSet<NhanVien> NhanVienTB {get;set;}
            public DbSet<Thuoc> ThuocTB {get;set;}
            public DbSet<TaiKhoan> TaiKhoanTB { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }

    }
}
