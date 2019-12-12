using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NhaKhoaMVC5.Models;

namespace NhaKhoaMVC5.DAL
{
    public class NhaKhoaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NhaKhoaContext>
    {
        protected override void Seed(NhaKhoaContext context)
        {
            var dskh = new List<KhachHang>
            {
                new KhachHang{MaKH_ID="kh001", TenKH="khach 1",NgaySinh=DateTime.Parse("2018-02-13") },
                new KhachHang{MaKH_ID="kh002",TenKH="khach 2",NgaySinh=DateTime.Parse("2019-1-20")},
                new KhachHang{MaKH_ID="kh003", TenKH="khach 3",NgaySinh=DateTime.Parse("2018-02-13") },
                new KhachHang{MaKH_ID="kh004", TenKH="khach 4",NgaySinh=DateTime.Parse("2018-01-14") },
                new KhachHang{MaKH_ID="kh005", TenKH="khach 5",NgaySinh=DateTime.Parse("2018-05-19") },
            };
            dskh.ForEach(s => context.KhachHangTB.Add(s));
            context.SaveChanges();

            var dscv = new List<ChucVu>
            {
                new ChucVu{MaCV_ID="ns",TenCV="Nha si"},
                new ChucVu{MaCV_ID="tt",TenCV="Tiep tan"}
            };
            dscv.ForEach(s => context.ChucVuTB.Add(s));
            context.SaveChanges();

            var dsnv = new List<NhanVien>
            {
                new NhanVien{MaNV_ID="nv001", TenNV="nhan vien 1",MaCV="ns",NgaySinh=DateTime.Parse("2018-02-13"),Sdt="0909090909" },
                new NhanVien{MaNV_ID="nv002", TenNV="nhan vien 2",MaCV="ns",NgaySinh=DateTime.Parse("2018-02-13"),Sdt="0909888844" },
                new NhanVien{MaNV_ID="nv003", TenNV="nhan vien 3",MaCV="tt",NgaySinh=DateTime.Parse("2018-02-13"),Sdt="0979797979" }
            };
            dsnv.ForEach(s => context.NhanVienTB.Add(s));
            context.SaveChanges();

            var dstk = new List<TaiKhoan>
            {   new TaiKhoan { MaNV_ID="nv001",MatKhau="123456",TenTaiKhoan_ID="taikhoan1"},
                new TaiKhoan{MaNV_ID="nv002",MatKhau="654322",TenTaiKhoan_ID="taikhoan2"}
            };
            dstk.ForEach(s => context.TaiKhoanTB.Add(s));
            context.SaveChanges();

            var dsth = new List<Thuoc>
            {
                new Thuoc {MaThuoc_ID="th001",TenThuoc="Thuoc dau rang",GhiChu="khong",Gia=20000,SoLuong=1000 },
                new Thuoc {MaThuoc_ID="th002",TenThuoc="Thuoc dau bung",GhiChu="k phai nha khoa",Gia=10000,SoLuong=1000 },
                new Thuoc {MaThuoc_ID="th003",TenThuoc="Thuoc dau Mat",GhiChu="khoa Mat",Gia=30000,SoLuong=1000 }
            };
            dsth.ForEach(s => context.ThuocTB.Add(s));
            context.SaveChanges();

            var dsdv = new List<DichVu>
            {
                new DichVu{MaDV_ID="dv001",TenDV="Tay trang rang",Gia=150000 },
                new DichVu{MaDV_ID="dv002",TenDV="Khoan rang",Gia=100000}
            };
            dsdv.ForEach(s => context.DichVuTB.Add(s));
            context.SaveChanges();

            var dsyc = new List<YeuCau>
            {
                new YeuCau{MaYC_ID="yc001",MaNhaSi="nv001",/*MaTiepTan="nv003",*/MaKH="kh005",NgayYC=DateTime.Parse("2019-12-1"),TongTien=310000},
                new YeuCau{MaYC_ID="yc002",MaNhaSi="nv002",/*MaTiepTan="nv003",*/MaKH="kh002",NgayYC=DateTime.Parse("2019-6-5"),TongTien=330000}
            };
            dsyc.ForEach(s => context.YeuCauTB.Add(s));
            context.SaveChanges();

            var dsctth = new List<ChiTietYeuCau_Thuoc>
            {
                new ChiTietYeuCau_Thuoc{MaYC_ID="yc001",MaThuoc_ID="th002",SoLuong=3},
                new ChiTietYeuCau_Thuoc{MaYC_ID="yc002",MaThuoc_ID="th003",SoLuong=2},
                new ChiTietYeuCau_Thuoc{MaYC_ID="yc001",MaThuoc_ID="th003",SoLuong=1},
                new ChiTietYeuCau_Thuoc{MaYC_ID="yc002",MaThuoc_ID="th002",SoLuong=2}
            };
            dsctth.ForEach(s => context.ChiTietYeuCauThuoc.Add(s));
            context.SaveChanges();

            var dschdv = new List<ChiTietYeuCau_DichVu>
            {
                new ChiTietYeuCau_DichVu{MaYC_ID="yc001",MaDV_ID="dv001"},
                new ChiTietYeuCau_DichVu{MaYC_ID="yc001",MaDV_ID="dv002"},
                new ChiTietYeuCau_DichVu{MaYC_ID="yc002",MaDV_ID="dv001"},
                new ChiTietYeuCau_DichVu{MaYC_ID="yc002",MaDV_ID="dv002"}
            };
            dschdv.ForEach(s => context.ChiTietYeuCauDichVu.Add(s));
            context.SaveChanges();

            

            


        }
    }
}
