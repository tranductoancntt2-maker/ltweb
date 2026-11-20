using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TranDucToan_241230866.Models;

[Table("Sach")]
public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    [Column("MaTL")]
    public int MaTl { get; set; }

    [Required(ErrorMessage ="Tên sách không được để trống")]
    [StringLength(100)]
    public string TenSach { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(typeof(decimal), "50", "1000", ErrorMessage ="Giá phải từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [StringLength(100)]
    [RegularExpression(@"(?i)^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi jpg|jpeg|png|webp")]
    public string? Anh { get; set; }

    [ForeignKey("MaTl")]
    [InverseProperty("Saches")]
    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
