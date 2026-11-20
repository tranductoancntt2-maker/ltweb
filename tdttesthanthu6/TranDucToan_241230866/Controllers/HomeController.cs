using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TranDucToan_241230866.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace TranDucToan_241230866.Controllers
{
    public class HomeController : Controller
    {
        public readonly QLNhaSachContext db;
        public HomeController(QLNhaSachContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var dsTheLoai = await db.TheLoais.ToListAsync();
            ViewBag.TheLoais = dsTheLoai;
            var dsSach = await db.Saches.Where(s=>s.Gia>=100).ToListAsync();
            return View(dsSach);
        }

        public async Task<IActionResult> LocSach(int maTl)
        {
            var dsSach = await db.Saches.Where(s => s.MaTl == maTl && s.Gia >= 100).ToListAsync();
            return PartialView("_DanhSachSach", dsSach);
        }
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Sach s)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(s);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View(s);
        }
    }
    
}
