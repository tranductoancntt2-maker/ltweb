using System.Globalization;

namespace QuanLySinhVien;

public class StudentConsoleView
{

    // NHAP CHUOI BAT BUOC
    public string NhapChuoiBatBuoc(
        string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);

            string? duLieu =
                Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(duLieu))
            {
                return duLieu.Trim();
            }

            Console.WriteLine(
                "Du lieu khong duoc de trong!");
        }
    }

    // NHAP NGAY SINH
    public DateTime NhapNgaySinh()
    {
        while (true)
        {
            Console.Write(
                "Ngay sinh (dd/MM/yyyy): ");

            string? duLieu =
                Console.ReadLine();

            bool hopLe =
                DateTime.TryParseExact(
                    duLieu,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime ngaySinh);

            if (hopLe &&
                StudentValidator.KiemTraNgaySinh(
                    ngaySinh))
            {
                return ngaySinh;
            }

            Console.WriteLine(
                "Ngay sinh khong hop le!");
        }
    }

    // NHAP GPA THEO THANG 10
    public double NhapGPA()
    {
        while (true)
        {
            Console.Write(
                "GPA (0 - 10): ");

            string? duLieu =
                Console.ReadLine();

            if (double.TryParse(
                duLieu,
                out double gpa))
            {
                if (StudentValidator.KiemTraGPA(
                    gpa))
                {
                    return gpa;
                }
            }

            Console.WriteLine(
                "GPA phai nam trong khoang tu 0 den 10!");
        }
    }

    // NHAP EMAIL
    public string NhapEmail()
    {
        while (true)
        {
            Console.Write("Email: ");

            string? email =
                Console.ReadLine();

            if (StudentValidator.KiemTraEmail(
                email))
            {
                return email!;
            }

            Console.WriteLine(
                "Email khong dung dinh dang!");
        }
    }

    // NHAP THONG TIN SINH VIEN
    public Student NhapSinhVien()
    {
        Console.WriteLine(
            "===== NHAP THONG TIN SINH VIEN =====");

        string maSinhVien =
            NhapChuoiBatBuoc(
                "Ma sinh vien: ");

        string hoTen =
            NhapChuoiBatBuoc(
                "Ho ten: ");

        DateTime ngaySinh =
            NhapNgaySinh();

        string gioiTinh =
            NhapChuoiBatBuoc(
                "Gioi tinh: ");

        string email =
            NhapEmail();

        string soDienThoai =
            NhapChuoiBatBuoc(
                "So dien thoai: ");

        string nganhHoc =
            NhapChuoiBatBuoc(
                "Nganh hoc: ");

        double gpa =
            NhapGPA();

        string trangThaiHocTap =
            NhapChuoiBatBuoc(
                "Trang thai hoc tap: ");

        return new Student(
            maSinhVien,
            hoTen,
            ngaySinh,
            gioiTinh,
            email,
            soDienThoai,
            nganhHoc,
            gpa,
            trangThaiHocTap);
    }

    // HIEN THI MOT SINH VIEN
    public void HienThiSinhVien(
        Student sinhVien)
    {
        Console.WriteLine(
            "------------------------------------------");

        Console.WriteLine(sinhVien);

        Console.WriteLine(
            "------------------------------------------");
    }

    // HIEN THI DANH SACH
    public void HienThiDanhSach(
        IEnumerable<Student> danhSach)
    {
        bool coSinhVien = false;

        foreach (Student sinhVien in danhSach)
        {
            coSinhVien = true;

            HienThiSinhVien(sinhVien);
        }

        if (!coSinhVien)
        {
            Console.WriteLine(
                "Khong co sinh vien nao.");
        }
    }

    // TAM DUNG
    public void TamDung()
    {
        Console.WriteLine();
        Console.WriteLine(
            "Nhan Enter de tiep tuc...");

        Console.ReadLine();
    }
}