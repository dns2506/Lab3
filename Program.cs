using System;
using System.Collections.Generic;

namespace Lab3_bai10
{
    // Lớp trừu tượng gốc quản lý người học
    public abstract class NguoiHoc
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }
        public abstract decimal TinhHocPhi();
        public abstract string HienThiThongTin();
    }

    // Lớp SinhVienChinhQuy kế thừa NguoiHoc
    public class SinhVienChinhQuy : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 450000m;
        }

        public override string HienThiThongTin()
        {
            return $"[Chính quy] Mã: {MaSV} | Họ tên: {HoTen} | Số TC: {SoTinChi} | Học phí: {TinhHocPhi():N0} VNĐ";
        }
    }

    // Lớp SinhVienLienThong kế thừa NguoiHoc
    public class SinhVienLienThong : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 520000m;
        }

        public override string HienThiThongTin()
        {
            return $"[Liên thông] Mã: {MaSV} | Họ tên: {HoTen} | Số TC: {SoTinChi} | Học phí: {TinhHocPhi():N0} VNĐ";
        }
    }

    // Hệ thống quản lý nâng cấp
    public class QuanLySinhVien
    {
        private List<NguoiHoc> danhSach = new List<NguoiHoc>();

        public void ThemSinhVien(NguoiHoc sv)
        {
            danhSach.Add(sv);
        }

        public void HienThiDanhSach()
        {
            Console.WriteLine("--- DANH SÁCH TẤT CẢ SINH VIÊN ---");
            foreach (var sv in danhSach)
            {
                Console.WriteLine(sv.HienThiThongTin());
            }
        }

        public void TimKiemTheoTen(string ten)
        {
            Console.WriteLine($"--- KẾT QUẢ TÌM KIẾM THEO TÊN: '{ten}' ---");
            bool found = false;
            foreach (var sv in danhSach)
            {
                if (sv.HoTen.IndexOf(ten, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine(sv.HienThiThongTin());
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Không tìm thấy sinh viên phù hợp!");
        }

        public void ThongKeVaTongHocPhi()
        {
            int demCQ = 0, demLT = 0;
            decimal tongTien = 0;

            foreach (var sv in danhSach)
            {
                tongTien += sv.TinhHocPhi();
                if (sv is SinhVienChinhQuy) demCQ++;
                else if (sv is SinhVienLienThong) demLT++;
            }

            Console.WriteLine("--- THỐNG KÊ HỆ THỐNG ---");
            Console.WriteLine($"- Tổng số lượng sinh viên: {danhSach.Count}");
            Console.WriteLine($"- Số lượng Sinh viên Chính quy: {demCQ}");
            Console.WriteLine($"- Số lượng Sinh viên Liên thông: {demLT}");
            Console.WriteLine($"- Tổng học phí toàn trường cần thu: {tongTien:N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị tiếng Việt có dấu trong Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== DEMO BÀI 10: NÂNG CẤP QUẢN LÝ SINH VIÊN ===\n");

            QuanLySinhVien ql = new QuanLySinhVien();

            // Thêm các đối tượng sinh viên đa hình vào hệ thống
            ql.ThemSinhVien(new SinhVienChinhQuy { MaSV = "SV001", HoTen = "Đỗ Ngọc Sơn", SoTinChi = 18 });
            ql.ThemSinhVien(new SinhVienChinhQuy { MaSV = "SV002", HoTen = "Nguyễn Văn An", SoTinChi = 16 });
            ql.ThemSinhVien(new SinhVienLienThong { MaSV = "LT001", HoTen = "Trần Thị Bình", SoTinChi = 15 });
            ql.ThemSinhVien(new SinhVienLienThong { MaSV = "LT002", HoTen = "Lê Hoàng Long", SoTinChi = 12 });

            // 1. Hiển thị danh sách
            ql.HienThiDanhSach();
            Console.WriteLine();

            // 2. Thống kê và tính tổng học phí
            ql.ThongKeVaTongHocPhi();
            Console.WriteLine();

            // 3. Tìm kiếm sinh viên
            ql.TimKiemTheoTen("Sơn");

            Console.ReadKey();
        }
    }
}