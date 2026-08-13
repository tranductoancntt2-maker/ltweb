namespace QuanLySinhVien;

public class StudentService
{
    private readonly List<Student> danhSachSinhVien = new();

    // 1. THEM SINH VIEN
    public bool ThemSinhVien(Student sinhVien)
    {
        bool daTonTai = danhSachSinhVien.Any(sv =>
            sv.MaSinhVien.Equals(
                sinhVien.MaSinhVien,
                StringComparison.OrdinalIgnoreCase));

        if (daTonTai)
        {
            return false;
        }

        danhSachSinhVien.Add(sinhVien);

        return true;
    }

    // 2. LAY DANH SACH SINH VIEN
    public List<Student> LayDanhSachSinhVien()
    {
        return danhSachSinhVien;
    }

    // 3. TIM THEO MA SINH VIEN
    public Student? TimTheoMa(string maSinhVien)
    {
        return danhSachSinhVien.FirstOrDefault(sv =>
            sv.MaSinhVien.Equals(
                maSinhVien,
                StringComparison.OrdinalIgnoreCase));
    }

    // 4. TIM GAN DUNG THEO HO TEN
    public List<Student> TimGanDungTheoHoTen(
        string tuKhoa)
    {
        return danhSachSinhVien
            .Where(sv =>
                sv.HoTen.Contains(
                    tuKhoa,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // 5. CAP NHAT SINH VIEN
    public bool CapNhatSinhVien(
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
        Student? sinhVien = TimTheoMa(maSinhVien);

        if (sinhVien == null)
        {
            return false;
        }

        sinhVien.HoTen = hoTen;
        sinhVien.NgaySinh = ngaySinh;
        sinhVien.GioiTinh = gioiTinh;
        sinhVien.Email = email;
        sinhVien.SoDienThoai = soDienThoai;
        sinhVien.NganhHoc = nganhHoc;
        sinhVien.GPA = gpa;
        sinhVien.TrangThaiHocTap = trangThaiHocTap;

        return true;
    }

    // 6. XOA SINH VIEN
    public bool XoaSinhVien(string maSinhVien)
    {
        Student? sinhVien = TimTheoMa(maSinhVien);

        if (sinhVien == null)
        {
            return false;
        }

        danhSachSinhVien.Remove(sinhVien);

        return true;
    }

    // 7. SAP XEP THEO HO TEN
    public List<Student> SapXepTheoHoTen()
    {
        return danhSachSinhVien
            .OrderBy(sv => sv.HoTen)
            .ToList();
    }

    // 8. SAP XEP THEO GPA
    public List<Student> SapXepTheoGPA()
    {
        return danhSachSinhVien
            .OrderByDescending(sv => sv.GPA)
            .ToList();
    }

    // 9. GPA TU 8 TRO LEN
    public List<Student> LaySinhVienGPA8TroLen()
    {
        return danhSachSinhVien
            .Where(sv => sv.GPA >= 8)
            .ToList();
    }

    // 10. SINH VIEN CO GPA CAO NHAT
    public List<Student> LaySinhVienGPAcaoNhat()
    {
        if (danhSachSinhVien.Count == 0)
        {
            return new List<Student>();
        }

        double gpaCaoNhat =
            danhSachSinhVien.Max(sv => sv.GPA);

        return danhSachSinhVien
            .Where(sv => sv.GPA == gpaCaoNhat)
            .ToList();
    }

    // 11. TINH GPA TRUNG BINH
    public double TinhGPATrungBinh()
    {
        if (danhSachSinhVien.Count == 0)
        {
            return 0;
        }

        return danhSachSinhVien
            .Average(sv => sv.GPA);
    }

    // 12. THONG KE THEO NGANH
    public Dictionary<string, int> ThongKeTheoNganh()
    {
        return danhSachSinhVien
            .GroupBy(sv => sv.NganhHoc)
            .ToDictionary(
                nhom => nhom.Key,
                nhom => nhom.Count());
    }

    // 13. THONG KE THEO TRANG THAI
    public Dictionary<string, int> ThongKeTheoTrangThai()
    {
        return danhSachSinhVien
            .GroupBy(sv => sv.TrangThaiHocTap)
            .ToDictionary(
                nhom => nhom.Key,
                nhom => nhom.Count());
    }
}