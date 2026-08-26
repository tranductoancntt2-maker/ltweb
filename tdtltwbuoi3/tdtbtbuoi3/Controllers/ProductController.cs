using Microsoft.AspNetCore.Mvc;
using tdtbtbuoi3.Models;

namespace tdtbtbuoi3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 500000,
                    SalePrice = 450000,
                    CategoryId = 1,
                    Description = "Mô tả Product 1",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product1.webp"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 700000,
                    SalePrice = 650000,
                    CategoryId = 2,
                    Description = "Mô tả Product 2",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product2.webp"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Price = 550000,
                    SalePrice = 500000,
                    CategoryId = 3,
                    Description = "Mô tả Product 3",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product3.webp"
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Price = 550000,
                    SalePrice = 480000,
                    CategoryId = 1,
                    Description = "Mô tả Product 4",
                    Status = 0,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product4.webp"
                }
            };

            ViewBag.Products = products;
            ViewBag.Categories = categories;

            return View();
        }

        public IActionResult Details(int id)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 500000,
                    SalePrice = 450000,
                    CategoryId = 1,
                    Description = "Mô tả Product 1",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product01.webp"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 700000,
                    SalePrice = 650000,
                    CategoryId = 2,
                    Description = "Mô tả Product 2",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product2.webp"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Price = 550000,
                    SalePrice = 500000,
                    CategoryId = 3,
                    Description = "Mô tả Product 3",
                    Status = 1,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product3.webp"
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Price = 550000,
                    SalePrice = 480000,
                    CategoryId = 1,
                    Description = "Mô tả Product 4",
                    Status = 0,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product4.webp"
                }
            };

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
