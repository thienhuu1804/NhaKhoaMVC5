namespace NhaKhoaMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inititialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietYeuCau_DichVu",
                c => new
                    {
                        Stt_ID = c.Int(nullable: false, identity: true),
                        MaDV_ID = c.String(maxLength: 128),
                        MaYC_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Stt_ID)
                .ForeignKey("dbo.DichVu", t => t.MaDV_ID)
                .ForeignKey("dbo.YeuCau", t => t.MaYC_ID)
                .Index(t => t.MaDV_ID)
                .Index(t => t.MaYC_ID);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDV_ID = c.String(nullable: false, maxLength: 128),
                        TenDV = c.String(),
                        Gia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDV_ID);
            
            CreateTable(
                "dbo.YeuCau",
                c => new
                    {
                        MaYC_ID = c.String(nullable: false, maxLength: 128),
                        MaNhaSi = c.String(maxLength: 128),
                        MaKH = c.String(maxLength: 128),
                        NgayYC = c.DateTime(nullable: false),
                        TongTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaYC_ID)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.NhanVien", t => t.MaNhaSi)
                .Index(t => t.MaNhaSi)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.ChiTietYeuCau_Thuoc",
                c => new
                    {
                        Stt = c.Int(nullable: false, identity: true),
                        MaYC_ID = c.String(maxLength: 128),
                        MaThuoc_ID = c.String(maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Stt)
                .ForeignKey("dbo.Thuoc", t => t.MaThuoc_ID)
                .ForeignKey("dbo.YeuCau", t => t.MaYC_ID)
                .Index(t => t.MaYC_ID)
                .Index(t => t.MaThuoc_ID);
            
            CreateTable(
                "dbo.Thuoc",
                c => new
                    {
                        MaThuoc_ID = c.String(nullable: false, maxLength: 128),
                        TenThuoc = c.String(),
                        GhiChu = c.String(),
                        Gia = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaThuoc_ID);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH_ID = c.String(nullable: false, maxLength: 128),
                        TenKH = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH_ID);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV_ID = c.String(nullable: false, maxLength: 128),
                        MaCV = c.String(maxLength: 128),
                        TenNV = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        Sdt = c.String(),
                    })
                .PrimaryKey(t => t.MaNV_ID)
                .ForeignKey("dbo.ChucVu", t => t.MaCV)
                .Index(t => t.MaCV);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        MaCV_ID = c.String(nullable: false, maxLength: 128),
                        TenCV = c.String(),
                    })
                .PrimaryKey(t => t.MaCV_ID);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TenTaiKhoan_ID = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(),
                        MaNV_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TenTaiKhoan_ID)
                .ForeignKey("dbo.NhanVien", t => t.MaNV_ID)
                .Index(t => t.MaNV_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoan", "MaNV_ID", "dbo.NhanVien");
            DropForeignKey("dbo.YeuCau", "MaNhaSi", "dbo.NhanVien");
            DropForeignKey("dbo.NhanVien", "MaCV", "dbo.ChucVu");
            DropForeignKey("dbo.YeuCau", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietYeuCau_Thuoc", "MaYC_ID", "dbo.YeuCau");
            DropForeignKey("dbo.ChiTietYeuCau_Thuoc", "MaThuoc_ID", "dbo.Thuoc");
            DropForeignKey("dbo.ChiTietYeuCau_DichVu", "MaYC_ID", "dbo.YeuCau");
            DropForeignKey("dbo.ChiTietYeuCau_DichVu", "MaDV_ID", "dbo.DichVu");
            DropIndex("dbo.TaiKhoan", new[] { "MaNV_ID" });
            DropIndex("dbo.NhanVien", new[] { "MaCV" });
            DropIndex("dbo.ChiTietYeuCau_Thuoc", new[] { "MaThuoc_ID" });
            DropIndex("dbo.ChiTietYeuCau_Thuoc", new[] { "MaYC_ID" });
            DropIndex("dbo.YeuCau", new[] { "MaKH" });
            DropIndex("dbo.YeuCau", new[] { "MaNhaSi" });
            DropIndex("dbo.ChiTietYeuCau_DichVu", new[] { "MaYC_ID" });
            DropIndex("dbo.ChiTietYeuCau_DichVu", new[] { "MaDV_ID" });
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.ChucVu");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.Thuoc");
            DropTable("dbo.ChiTietYeuCau_Thuoc");
            DropTable("dbo.YeuCau");
            DropTable("dbo.DichVu");
            DropTable("dbo.ChiTietYeuCau_DichVu");
        }
    }
}
