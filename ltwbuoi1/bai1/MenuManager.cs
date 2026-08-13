namespace QuanLySinhVien;

public class MenuManager
{
    private readonly StudentService service;
    private readonly StudentConsoleView view;

    public MenuManager(
        StudentService service,
        StudentConsoleView view)
    {
        this.service = service;
        this.view = view;
    }

    // CHAY CHUONG TRINH
    public void Chay()
    {
        while (true)
        {
            Console.Clear();

            HienThiMenu();

            Console.Write(
                "Chon chuc nang: ");

            string? luaChon =
                Console.ReadLine();

            Console.Clear();

            switch (luaChon)
            {
                case "1":
                    ThemSinhVien();
                    break;

                case "2":
                    HienThiDanhSach();
                    break;

                case "3":
                    TimTheoMa();
                    break;

                case "4":
                    TimGanDungTheoHoTen();
                    break;

                case "5":
                    CapNhatSinhVien();
                    break;

                case "6":
                    XoaSinhVien();
                    break;

                case "7":
                    SapXepTheoHoTen();
                    break;

                case "8":
                    SapXepTheoGPA();
                    break;

                case "9":
                    HienThiSinhVienGPA8TroLen();
                    break;

                case "10":
                    HienThiSinhVienGPAcaoNhat();
                    break;

                case "11":
                    TinhGPATrungBinh();
                    break;

                case "12":
                    ThongKeTheoNganh();
                    break;

                case "13":
                    ThongKeTheoTrangThai();
                    break;

                case "0":
                    Console.WriteLine(
                        "Da thoat chuong trinh.");

                    return;

                default:
                    Console.WriteLine(
                        "Lua chon khong hop le!");

                    view.TamDung();
                    break;
            }
        }
    }

    // HIEN THI MENU
    private void HienThiMenu()
    {

        Console.WriteLine(
            "          QUAN LY SINH VIEN        ");

        Console.WriteLine(
            "----------------------------------------");

        Console.WriteLine(
            "1.  Them sinh vien");

        Console.WriteLine(
            "2.  Hien thi danh sach");

        Console.WriteLine(
            "3.  Tim sinh vien theo ma");

        Console.WriteLine(
            "4.  Tim gan dung theo ho ten");

        Console.WriteLine(
            "5.  Cap nhat sinh vien");

        Console.WriteLine(
            "6.  Xoa sinh vien");

        Console.WriteLine(
            "7.  Sap xep theo ho ten");

        Console.WriteLine(
            "8.  Sap xep theo GPA");

        Console.WriteLine(
            "9.  Hien thi sinh vien co GPA tu 8 tro len");

        Console.WriteLine(
            "10. Hien thi sinh vien co GPA cao nhat");

        Console.WriteLine(
            "11. Tinh GPA trung binh toan bo");

        Console.WriteLine(
            "12. Thong ke sinh vien theo nganh");

        Console.WriteLine(
            "13. Thong ke sinh vien theo trang thai");

        Console.WriteLine(
            "0.  Thoat");
    }

    // 1. THEM SINH VIEN
    private void ThemSinhVien()
    {
        Console.WriteLine(
            "===== THEM SINH VIEN =====");

        Student sinhVien =
            view.NhapSinhVien();

        bool ketQua =
            service.ThemSinhVien(sinhVien);

        if (ketQua)
        {
            Console.WriteLine(
                "Them sinh vien thanh cong!");
        }
        else
        {
            Console.WriteLine(
                "Ma sinh vien da ton tai!");
        }

        view.TamDung();
    }

    // 2. HIEN THI DANH SACH
    private void HienThiDanhSach()
    {
        Console.WriteLine(
            "===== DANH SACH SINH VIEN =====");

        view.HienThiDanhSach(
            service.LayDanhSachSinhVien());

        view.TamDung();
    }

    // 3. TIM THEO MA
    private void TimTheoMa()
    {
        Console.WriteLine(
            "===== TIM SINH VIEN THEO MA =====");

        string maSinhVien =
            view.NhapChuoiBatBuoc(
                "Nhap ma sinh vien: ");

        Student? sinhVien =
            service.TimTheoMa(maSinhVien);

        if (sinhVien == null)
        {
            Console.WriteLine(
                "Khong tim thay sinh vien!");
        }
        else
        {
            view.HienThiSinhVien(sinhVien);
        }

        view.TamDung();
    }

    // 4. TIM GAN DUNG THEO HO TEN
    private void TimGanDungTheoHoTen()
    {
        Console.WriteLine(
            "===== TIM GAN DUNG THEO HO TEN =====");

        string tuKhoa =
            view.NhapChuoiBatBuoc(
                "Nhap tu khoa ho ten: ");

        List<Student> danhSach =
            service.TimGanDungTheoHoTen(
                tuKhoa);

        view.HienThiDanhSach(danhSach);

        view.TamDung();
    }

    // 5. CAP NHAT
    private void CapNhatSinhVien()
    {
        Console.WriteLine(
            "===== CAP NHAT SINH VIEN =====");

        string maSinhVien =
            view.NhapChuoiBatBuoc(
                "Nhap ma sinh vien can cap nhat: ");

        Student? sinhVien =
            service.TimTheoMa(maSinhVien);

        if (sinhVien == null)
        {
            Console.WriteLine(
                "Khong tim thay sinh vien!");

            view.TamDung();

            return;
        }

        Console.WriteLine(
            "Thong tin hien tai:");

        view.HienThiSinhVien(sinhVien);

        Console.WriteLine();
        Console.WriteLine(
            "Nhap thong tin moi:");

        string hoTen =
            view.NhapChuoiBatBuoc(
                "Ho ten: ");

        DateTime ngaySinh =
            view.NhapNgaySinh();

        string gioiTinh =
            view.NhapChuoiBatBuoc(
                "Gioi tinh: ");

        string email =
            view.NhapEmail();

        string soDienThoai =
            view.NhapChuoiBatBuoc(
                "So dien thoai: ");

        string nganhHoc =
            view.NhapChuoiBatBuoc(
                "Nganh hoc: ");

        double gpa =
            view.NhapGPA();

        string trangThaiHocTap =
            view.NhapChuoiBatBuoc(
                "Trang thai hoc tap: ");

        bool ketQua =
            service.CapNhatSinhVien(
                maSinhVien,
                hoTen,
                ngaySinh,
                gioiTinh,
                email,
                soDienThoai,
                nganhHoc,
                gpa,
                trangThaiHocTap);

        if (ketQua)
        {
            Console.WriteLine(
                "Cap nhat sinh vien thanh cong!");
        }
        else
        {
            Console.WriteLine(
                "Cap nhat sinh vien that bai!");
        }

        view.TamDung();
    }

    // 6. XOA
    private void XoaSinhVien()
    {
        Console.WriteLine(
            "===== XOA SINH VIEN =====");

        string maSinhVien =
            view.NhapChuoiBatBuoc(
                "Nhap ma sinh vien can xoa: ");

        Student? sinhVien =
            service.TimTheoMa(maSinhVien);

        if (sinhVien == null)
        {
            Console.WriteLine(
                "Khong tim thay sinh vien!");

            view.TamDung();

            return;
        }

        view.HienThiSinhVien(sinhVien);

        Console.Write(
            "Ban co chac muon xoa? (Y/N): ");

        string? xacNhan =
            Console.ReadLine();

        if (xacNhan?.Equals(
            "Y",
            StringComparison.OrdinalIgnoreCase) == true)
        {
            bool ketQua =
                service.XoaSinhVien(maSinhVien);

            if (ketQua)
            {
                Console.WriteLine(
                    "Xoa sinh vien thanh cong!");
            }
            else
            {
                Console.WriteLine(
                    "Xoa sinh vien that bai!");
            }
        }
        else
        {
            Console.WriteLine(
                "Da huy thao tac xoa.");
        }

        view.TamDung();
    }

    // 7. SAP XEP THEO HO TEN
    private void SapXepTheoHoTen()
    {
        Console.WriteLine(
            "===== SAP XEP THEO HO TEN =====");

        List<Student> danhSach =
            service.SapXepTheoHoTen();

        view.HienThiDanhSach(danhSach);

        view.TamDung();
    }

    // 8. SAP XEP THEO GPA
    private void SapXepTheoGPA()
    {
        Console.WriteLine(
            "===== SAP XEP THEO GPA =====");

        List<Student> danhSach =
            service.SapXepTheoGPA();

        view.HienThiDanhSach(danhSach);

        view.TamDung();
    }

    // 9. GPA TU 8 TRO LEN
    private void HienThiSinhVienGPA8TroLen()
    {
        Console.WriteLine(
            "===== SINH VIEN CO GPA TU 8 TRO LEN =====");

        List<Student> danhSach =
            service.LaySinhVienGPA8TroLen();

        view.HienThiDanhSach(danhSach);

        view.TamDung();
    }

    // 10. GPA CAO NHAT
    private void HienThiSinhVienGPAcaoNhat()
    {
        Console.WriteLine(
            "===== SINH VIEN CO GPA CAO NHAT =====");

        List<Student> danhSach =
            service.LaySinhVienGPAcaoNhat();

        view.HienThiDanhSach(danhSach);

        view.TamDung();
    }

    // 11. GPA TRUNG BINH
    private void TinhGPATrungBinh()
    {
        Console.WriteLine(
            "===== GPA TRUNG BINH TOAN BO =====");

        if (service.LayDanhSachSinhVien().Count == 0)
        {
            Console.WriteLine(
                "Chua co sinh vien.");
        }
        else
        {
            double gpaTrungBinh =
                service.TinhGPATrungBinh();

            Console.WriteLine(
                $"GPA trung binh: {gpaTrungBinh:F2}/10");
        }

        view.TamDung();
    }

    // 12. THONG KE THEO NGANH
    private void ThongKeTheoNganh()
    {
        Console.WriteLine(
            "===== THONG KE SINH VIEN THEO NGANH =====");

        Dictionary<string, int> thongKe =
            service.ThongKeTheoNganh();

        if (thongKe.Count == 0)
        {
            Console.WriteLine(
                "Chua co du lieu.");
        }
        else
        {
            foreach (var item in thongKe)
            {
                Console.WriteLine(
                    $"Nganh: {item.Key,-25} | So luong: {item.Value}");
            }
        }

        view.TamDung();
    }

    // 13. THONG KE THEO TRANG THAI
    private void ThongKeTheoTrangThai()
    {
        Console.WriteLine(
            "===== THONG KE SINH VIEN THEO TRANG THAI =====");

        Dictionary<string, int> thongKe =
            service.ThongKeTheoTrangThai();

        if (thongKe.Count == 0)
        {
            Console.WriteLine(
                "Chua co du lieu.");
        }
        else
        {
            foreach (var item in thongKe)
            {
                Console.WriteLine(
                    $"Trang thai: {item.Key,-20} | So luong: {item.Value}");
            }
        }

        view.TamDung();
    }
}