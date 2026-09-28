using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tdtbuoi7demo.Models
{
    public class tdtMember
    {
        public int Id { get; set; }
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 20 ký tự.")]
        public string TdtUserName { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string TdtPassword { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email.")]
        public string TdtEmail { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^0\d{9,9}$", ErrorMessage = "Số điện thoại phải có 10 chữ số, bắt đầu bằng số 0")]
        [Phone(ErrorMessage = "Vui lòng nhập đúng định dạng số điện thoại.")]
        public string TdtPhone { get; set; }

    }
}
