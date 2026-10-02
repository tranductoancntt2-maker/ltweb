using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace TdtLab5BT.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }

        [
            Display(Name = "Tên sản phẩm"),
            Required(ErrorMessage = "Tên sản phẩm không được để trống."),
            MinLength(6, ErrorMessage = "Tên sản phẩm phải có ít nhất 6 ký tự."),
            MaxLength(150, ErrorMessage = "Tên sản phẩm không được vượt quá 150 ký tự.")
        ]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; } = string.Empty;
        [Display(Name = "Chọn ảnh")]
        [Required(ErrorMessage = "Vui lòng chọn ảnh sản phẩm.")]
        public IFormFile ImageFile { get; set; }

        [
            Display(Name = "Giá sản phẩm"),
            DataType(DataType.Text),
            Required(ErrorMessage = "Giá sản phẩm không được để trống."),
            Range(typeof(decimal), "100000", "79228162514264337593543950335", ErrorMessage = "Giá sản phẩm phải từ 100.000 trở lên.")
        ]
        public decimal? Price { get; set; }

        [
            Display(Name = "Giá khuyến mãi"),
            DataType(DataType.Text),
            Required(ErrorMessage = "Giá khuyến mãi không được để trống."),
            Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Giá khuyến mãi không được là số âm.")
        ]
        public decimal? SalePrice { get; set; }

        [
            Display(Name = "Mô tả sản phẩm"),
            Required(ErrorMessage = "Mô tả sản phẩm không được để trống."),
            MaxLength(1500, ErrorMessage = "Mô tả sản phẩm không được vượt quá 1.500 ký tự."),
            ForbiddenWords(
                "die", "admin", "fack",
                "lừa đảo", "giả mạo", "hàng nhái", "hàng kém chất lượng",
                "hàng lỗi", "hàng cấm", "hàng giả",
                "hàng không rõ nguồn gốc", "hàng không đảm bảo chất lượng",
                "hàng không đạt tiêu chuẩn")
        ]
        public string Description { get; set; } = string.Empty;

        [
            Display(Name = "Danh mục"),
            Required(ErrorMessage = "Vui lòng chọn danh mục sản phẩm."),
            Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục sản phẩm.")
        ]
        public int? CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price.HasValue && SalePrice.HasValue)
            {
                if (SalePrice.Value > Price.Value * 0.9m)
                {
                    yield return new ValidationResult(
                        "Giá khuyến mãi phải thấp hơn hoặc bằng 90% giá sản phẩm (giảm ít nhất 10%).",
                        new[] { nameof(SalePrice) }
                    );
                }
            }
        }
    }
}
