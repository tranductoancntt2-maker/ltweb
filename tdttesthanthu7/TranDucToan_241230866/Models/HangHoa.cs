using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranDucToan_241230866.Models;

public partial class HangHoa
{
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Column(TypeName ="numeric(18,0)")]
    [Required(ErrorMessage ="Giá không được để trống")]
    [Range(typeof(decimal),"100", "5000", ErrorMessage ="Giá phải từ 100 đến 5000")]
    public decimal? Gia { get; set; }

    [StringLength(100)]
    [RegularExpression(@"(?i)^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Ảnh phải có đuôi jpg | png | gif | tiff")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
