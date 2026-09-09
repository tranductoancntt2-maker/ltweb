using Microsoft.AspNetCore.Mvc;
using tdtlab3demo.Models;

namespace tdtlab3demo.Controllers
{
    public class tdtBookController : Controller
    {
        protected Book book=new Book();
        public IActionResult Index()
        {
            ViewBag.authors=book.Authors;
            ViewBag.genres=book.Genres;
            var books=book.GetBookList();
            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }
        public PartialViewResult PopularBook()
        {
            var books = book.GetBookList();
            return PartialView("_PopularBook", books);
        }
    }
}
