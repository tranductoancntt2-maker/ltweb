using tdtbtlab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace tdtbtlab3.ViewComponents
{
    public class tdtHotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = new List<tdtProduct>
            {
                new tdtProduct
                {
                    Id = 101,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",
                },

                new tdtProduct
                {
                    Id = 102,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",             
                },

                new tdtProduct
                {
                    Id = 103,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/product.webp",
                }
            };

            return View(products);
        }
    }
}
