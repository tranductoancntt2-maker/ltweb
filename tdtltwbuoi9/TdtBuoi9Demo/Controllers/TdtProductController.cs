using Microsoft.AspNetCore.Mvc;

namespace TdtBuoi9Demo.Controllers
{
    public class TdtProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string keyword)
        {
            // Logic to search for products based on the keyword
            // For demonstration purposes, we'll just return the keyword
            ViewBag.Keyword = keyword;
            return View();
        }
        public IActionResult Hots()
        {
            // Logic to get hot products
            return View();
        }
        public IActionResult About()
        {
            // Logic to get about information
            return View();
        }
    }
}
