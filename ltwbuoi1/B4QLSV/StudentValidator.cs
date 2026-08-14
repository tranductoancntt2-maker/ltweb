using System.Net.Mail;

namespace QuanLySinhVien;

public static class StudentValidator
{
    // Kiem tra ma sinh vien
    public static bool KiemTraMaSinhVien(
        string? maSinhVien)
    {
        return !string.IsNullOrWhiteSpace(maSinhVien);
    }

    // Kiem tra ho ten
    public static bool KiemTraHoTen(
        string? hoTen)
    {
        return !string.IsNullOrWhiteSpace(hoTen);
    }

    // Kiem tra GPA 
    public static bool KiemTraGPA(
        double gpa)
    {
        return gpa >= 0 && gpa <= 10;
    }

    // Kiem tra email
    public static bool KiemTraEmail(
        string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        try
        {
            MailAddress mail =
                new MailAddress(email);

            return mail.Address == email;
        }
        catch
        {
            return false;
        }
    }

    // Kiem tra ngay sinh
    public static bool KiemTraNgaySinh(
        DateTime ngaySinh)
    {
        return ngaySinh <= DateTime.Today;
    }
}