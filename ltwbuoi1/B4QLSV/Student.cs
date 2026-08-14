namespace QuanLySinhVien;

public class Student
{
    // Static Member
    public static int TongSoSinhVien { get; private set; }

    // Properties
    public string MaSinhVien { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string GioiTinh { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }
    public string NganhHoc { get; set; }
    public double GPA { get; set; }
    public string TrangThaiHocTap { get; set; }

    // Constructor
    public Student(
        string maSinhVien,
        string hoTen,
        DateTime ngaySinh,
        string gioiTinh,
        string email,
        string soDienThoai,
        string nganhHoc,
        double gpa,
        string trangThaiHocTap)
    {
        MaSinhVien = maSinhVien;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        GioiTinh = gioiTinh;
        Email = email;
        SoDienThoai = soDienThoai;
        NganhHoc = nganhHoc;
        GPA = gpa;
        TrangThaiHocTap = trangThaiHocTap;

        TongSoSinhVien++;
    }

    public override string ToString()
    {
        return
            $"Ma sinh vien  : {MaSinhVien}\n" +
            $"Ho ten        : {HoTen}\n" +
            $"Ngay sinh     : {NgaySinh:dd/MM/yyyy}\n" +
            $"Gioi tinh     : {GioiTinh}\n" +
            $"Email         : {Email}\n" +
            $"So dien thoai : {SoDienThoai}\n" +
            $"Nganh hoc     : {NganhHoc}\n" +
            $"GPA           : {GPA:F2}/10\n" +
            $"Trang thai    : {TrangThaiHocTap}";
    }
}