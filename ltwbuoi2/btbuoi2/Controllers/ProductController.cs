using btbuoi2.Models;
using Microsoft.AspNetCore.Mvc;

namespace btbuoi2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 500000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product1.webp"
                },

                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 700000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product1.webp"
                },

                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product1.webp"
                },

                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Price = 550000,
                    CreatedAt = new DateTime(2020, 12, 25),
                    Image = "/images/product1.webp"
                }
            };

            return View(products);
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
            CreatedAt = new DateTime(2020, 12, 25),
            Image = "/images/product1.webp"
        },

        new Product
        {
            Id = 2,
            Name = "Product 2",
            Price = 700000,
            CreatedAt = new DateTime(2020, 12, 25),
            Image = "/images/product1.webp"
        },

        new Product
        {
            Id = 3,
            Name = "Product 3",
            Price = 550000,
            CreatedAt = new DateTime(2020, 12, 25),
            Image = "/images/product1.webp"
        },

        new Product
        {
            Id = 4,
            Name = "Product 4",
            Price = 550000,
            CreatedAt = new DateTime(2020, 12, 25),
            Image = "/images/product1.webp"
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
