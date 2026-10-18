using System;
using System.Collections.Generic;

namespace Lab3_bai6
{
    // Lớp trừu tượng NhanVien chứa thuộc tính chung và phương thức trừu tượng TinhLuong()
    public abstract class NhanVien
    {
        public string HoTen { get; set; }
        public abstract decimal TinhLuong();
    }

    // Lớp NhanVienVanPhong kế thừa NhanVien
    public class NhanVienVanPhong : NhanVien
    {
        public decimal LuongCoBan { get; set; }
        public int SoNgayLamViec { get; set; }

        public override decimal TinhLuong()
        {
            // Công thức: Lương cơ bản nhân với tỷ lệ ngày làm việc trên chuẩn 22 ngày
            return LuongCoBan * (SoNgayLamViec / 22m);
        }
    }

    // Lớp NhanVienKinhDoanh kế thừa NhanVien
    public class NhanVienKinhDoanh : NhanVien
    {
        public decimal LuongCung { get; set; }
        public decimal DoanhSo { get; set; }

        public override decimal TinhLuong()
        {
            // Công thức: Lương cứng cộng với 10% hoa hồng doanh số
            return LuongCung + (DoanhSo * 0.1m);
        }
    }

    // Lớp GiangVien kế thừa NhanVien
    public class GiangVien : NhanVien
    {
        public int SoTietDay { get; set; }
        public decimal DonGiaTiet { get; set; }

        public override decimal TinhLuong()
        {
            // Công thức: Số tiết dạy nhân với đơn giá một tiết
            return SoTietDay * DonGiaTiet;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập tiếng Việt cho Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== DEMO BÀI 6: HỆ THỐNG NHÂN VIÊN (TÍNH LƯƠNG ĐA HÌNH) ===");

            // Sử dụng danh sách đa hình chứa các loại nhân viên khác nhau
            List<NhanVien> dsNhanVien = new List<NhanVien>
            {
                new NhanVienVanPhong { HoTen = "Nguyễn Văn Hùng", LuongCoBan = 10000000m, SoNgayLamViec = 22 },
                new NhanVienKinhDoanh { HoTen = "Trần Thị Mai", LuongCung = 6000000m, DoanhSo = 50000000m },
                new GiangVien { HoTen = "Đỗ Ngọc Sơn", SoTietDay = 45, DonGiaTiet = 120000m }
            };

            foreach (var nv in dsNhanVien)
            {
                string chucVu = "";
                if (nv is NhanVienVanPhong) chucVu = "Nhân viên Văn phòng";
                else if (nv is NhanVienKinhDoanh) chucVu = "Nhân viên Kinh doanh";
                else if (nv is GiangVien) chucVu = "Giảng viên";

                Console.WriteLine($"- [{chucVu}] Họ tên: {nv.HoTen} | Lương thực nhận: {nv.TinhLuong():N0} VNĐ");
            }

            Console.ReadKey();
        }
    }
}