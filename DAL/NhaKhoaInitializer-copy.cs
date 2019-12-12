//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using NhaKhoa.Models;

//namespace NhaKhoa.DAL
//{
//    public class NhaKhoaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NhaKhoaContext>
//    {
//        protected override void Seed(NhaKhoaContext context)
//        {
//            var dskh = new List<KhachHang>
//            {
//                new KhachHang{maKH_ID="kh001", tenKH="khach 1",ngaySinh=DateTime.Parse("2018-02-13") },
//                new KhachHang{maKH_ID="kh002",tenKH="khach 2",ngaySinh=DateTime.Parse("2019-1-20")},
//                new KhachHang{maKH_ID="kh003", tenKH="khach 3",ngaySinh=DateTime.Parse("2018-02-13") },
//                new KhachHang{maKH_ID="kh004", tenKH="khach 4",ngaySinh=DateTime.Parse("2018-01-14") },
//                new KhachHang{maKH_ID="kh005", tenKH="khach 5",ngaySinh=DateTime.Parse("2018-05-19") },
//            };
//            dskh.ForEach(s => context.KhachHangTB.Add(s));
//            context.SaveChanges();

//            var dscv = new List<ChucVu>
//            {
//                new ChucVu{maCV_ID="ns",tenCV="Nha si"},
//                new ChucVu{maCV_ID="tt",tenCV="Tiep tan"}
//            };
//            dscv.ForEach(s => context.ChucVuTB.Add(s));
//            context.SaveChanges();

//            var dsnv = new List<NhanVien>
//            {
//                new NhanVien{maNV_ID="nv001", tenNV="nhan vien 1",maCV="ns",ngaySinh=DateTime.Parse("2018-02-13"),sdt="0909090909" },
//                new NhanVien{maNV_ID="nv002", tenNV="nhan vien 2",maCV="ns",ngaySinh=DateTime.Parse("2018-02-13"),sdt="0909888844" },
//                new NhanVien{maNV_ID="nv003", tenNV="nhan vien 3",maCV="tt",ngaySinh=DateTime.Parse("2018-02-13"),sdt="0979797979" }
//            };
//            dsnv.ForEach(s => context.NhanVienTB.Add(s));
//            context.SaveChanges();

//            var dsth = new List<Thuoc>
//            {
//                new Thuoc {maThuoc_ID="th001",tenThuoc="Thuoc dau rang",ghiChu="khong",gia=20000,soLuong=1000 },
//                new Thuoc {maThuoc_ID="th002",tenThuoc="Thuoc dau bung",ghiChu="k phai nha khoa",gia=10000,soLuong=1000 },
//                new Thuoc {maThuoc_ID="th003",tenThuoc="Thuoc dau mat",ghiChu="khoa mat",gia=30000,soLuong=1000 }
//            };
//            dsth.ForEach(s => context.ThuocTB.Add(s));
//            context.SaveChanges();

//            var dsdv = new List<DichVu>
//            {
//                new DichVu{maDV_ID="dv001",tenDV="Tay trang rang",gia=150000 },
//                new DichVu{maDV_ID="dv002",tenDV="Khoan rang",gia=100000}
//            };
//            dsdv.ForEach(s => context.DichVuTB.Add(s));
//            context.SaveChanges();

//            var dsyc = new List<YeuCau>
//            {
//                new YeuCau{maYC_ID="yc001",maNhaSi="nv001",maTiepTan="nv003",maKH="kh005", danhSachDichVu=new List<DichVu>{
//                                                                                                                        new DichVu{maDV_ID="dv001",tenDV="Tay trang rang",gia=150000 },
//                                                                                                                        new DichVu{maDV_ID="dv002",tenDV="Khoan rang",gia=100000},
//                                                                                                                                                                                            },danhSachThuoc=new List<Thuoc>{ new Thuoc {maThuoc_ID="th001",tenThuoc="Thuoc dau rang",ghiChu="khong",gia=20000,soLuong=2 }},ngayYC=DateTime.Parse("2019-10-12"),tongTien=290000
//                                                                                                                                                                                            },
//                new YeuCau{maYC_ID="yc002",maNhaSi="nv002",maTiepTan="nv003",maKH="kh002", danhSachDichVu=new List<DichVu>{
//                                                                                                                       new DichVu{maDV_ID="dv001",tenDV="Tay trang rang",gia=150000 },
//                                                                                                                        new DichVu{maDV_ID="dv002",tenDV="Khoan rang",gia=100000},
//                                                                                                                                                                                            },danhSachThuoc=new List<Thuoc>{ new Thuoc {maThuoc_ID="th001",tenThuoc="Thuoc dau rang",ghiChu="khong",gia=20000,soLuong=2 }},ngayYC=DateTime.Parse("2019-10-12"),tongTien=290000
//                                                                                                                                                                                            }
//            };
//            dsyc.ForEach(s => context.YeuCauTB.Add(s));
//            context.SaveChanges();


//        }
//    }
//}
