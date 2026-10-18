using System;
using System.Collections.Generic;

namespace Lab3_bai3
{
    // Lớp trừu tượng NguoiHoc chứa phương thức trừu tượng TinhHocPhi()
    public abstract class NguoiHoc
    {
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }

        // Phương thức trừu tượng buộc các lớp con phải override lại cách tính học phí riêng
        public abstract decimal TinhHocPhi();
    }

    // Lớp SinhVienChinhQuy kế thừa NguoiHoc
    public class SinhVienChinhQuy : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 450000m;
        }
    }

    // Lớp SinhVienLienThong kế thừa NguoiHoc
    public class SinhVienLienThong : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 520000m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập tiếng Việt cho Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== DEMO BÀI 3: LỚP TRỪU TƯỢNG HỌC PHÍ ===");

            // Khởi tạo danh sách các đối tượng người học (tính đa hình qua lớp cha NguoiHoc)
            List<NguoiHoc> danhSachNguoiHoc = new List<NguoiHoc>
            {
                new SinhVienChinhQuy { HoTen = "Đỗ Ngọc Sơn", SoTinChi = 18 },
                new SinhVienLienThong { HoTen = "Văn Bình", SoTinChi = 15 }
            };

            decimal tongTien = 0;
            foreach (var item in danhSachNguoiHoc)
            {
                decimal hocPhi = item.TinhHocPhi();
                tongTien += hocPhi;
                string loaiSV = item is SinhVienChinhQuy ? "Chính quy" : "Liên thông";

                Console.WriteLine($"- Sinh viên: {item.HoTen} ({loaiSV}) | Số tín: {item.SoTinChi} | Học phí: {hocPhi:N0} VNĐ");
            }

            Console.WriteLine($"=> Tổng học phí cần thu: {tongTien:N0} VNĐ");

            Console.ReadKey();
        }
    }
}