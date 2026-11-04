using System.ComponentModel.DataAnnotations;

namespace TdtTH2Lab4.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; } // Mã sinh viên

        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có từ 4 đến 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string? Name { get; set; } // Họ tên

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        [Display(Name = "Email")]
        public string? Email { get; set; } // Email

        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; } // Mật khẩu

        [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
        [Display(Name = "Ngành học")]
        public Branch? Branch { get; set; } // Ngành học

        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; } // Giới tính

        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; } // Hệ: true - chính quy, false - phi chính quy

        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; } // Địa chỉ

        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [DateOfBirthRange]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBorth { get; set; } // Ngày sinh

        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        [Display(Name = "Điểm")]
        public double? Score { get; set; } // Điểm

        // Bổ sung cho Phần 9 (Upload ảnh đại diện)
        [Display(Name = "Ảnh đại diện")]
        public string? AvatarUrl { get; set; }
    }
    public class DateOfBirthRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            if (value is DateTime date)
            {
                return date >= new DateTime(1963, 1, 1)
                    && date <= new DateTime(2005, 12, 31);
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Ngày sinh phải từ 01/01/1963 đến 31/12/2005";
        }
    }
}
