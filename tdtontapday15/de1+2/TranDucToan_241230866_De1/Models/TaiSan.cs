using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranDucToan_241230866_De1.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage ="Tên không được để trống")]
    public string TenTs { get; set; } = null!;

    [Column(TypeName ="numeric(18,0)")]
    [Required(ErrorMessage ="Giá không được để trống")]
    [Range(typeof(decimal), "1", "2000", ErrorMessage ="Giá phải từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [StringLength(100)]
    [RegularExpression(@"(?i)^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi .jpg | .jpeg | .png | .webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
