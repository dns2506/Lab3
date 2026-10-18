using System;
using System.Collections.Generic;

namespace Lab3_bai9
{
    // Khai báo Interface IPayment định nghĩa hợp đồng thanh toán
    public interface IPayment
    {
        bool ThanhToan(decimal soTien);
        string LayTenPhuongThuc();
    }

    // Lớp ThanhToanTienMat thực thi IPayment
    public class ThanhToanTienMat : IPayment
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.WriteLine($"-> Đã thu thành công {soTien:N0} VNĐ bằng Tiền mặt trực tiếp.");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Tiền mặt";
        }
    }

    // Lớp ChuyenKhoan thực thi IPayment
    public class ChuyenKhoan : IPayment
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.WriteLine($"-> Đã nhận thành công {soTien:N0} VNĐ qua Chuyển khoản ngân hàng (QR/IB).");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Chuyển khoản Ngân hàng";
        }
    }

    // Lớp ViDienTu thực thi IPayment
    public class ViDienTu : IPayment
    {
        public bool ThanhToan(decimal soTien)
        {
            Console.WriteLine($"-> Đã thanh toán thành công {soTien:N0} VNĐ qua Ví điện tử (MoMo / ZaloPay / VNPay).");
            return true;
        }

        public string LayTenPhuongThuc()
        {
            return "Ví điện tử";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập tiếng Việt cho Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== DEMO BÀI 9: HỆ THỐNG THANH TOÁN (INTERFACE) ===");

            // Sử dụng danh sách đa hình chứa các phương thức thanh toán khác nhau thông qua interface IPayment
            List<IPayment> dsThanhToan = new List<IPayment>
            {
                new ThanhToanTienMat(),
                new ChuyenKhoan(),
                new ViDienTu()
            };

            decimal soTienGiaoDich = 750000m; // Số tiền giả định cho đơn hàng
            Console.WriteLine($"Thực hiện giao dịch cho đơn hàng trị giá: {soTienGiaoDich:N0} VNĐ\n");

            foreach (var payment in dsThanhToan)
            {
                Console.WriteLine($"Phương thức chọn: {payment.LayTenPhuongThuc()}");
                payment.ThanhToan(soTienGiaoDich);
                Console.WriteLine("--------------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}