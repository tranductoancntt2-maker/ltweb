using Microsoft.AspNetCore.Mvc;
using tdtbtlab3.Models;

namespace tdtbtlab3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<tdtProduct>
            {
                new tdtProduct
                {
                    Id = 1,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",
                },

                new tdtProduct
                {
                    Id = 2,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",
                },

                new tdtProduct
                {
                    Id = 3,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",
                }
            };

            return View(products);
        }
    }
}