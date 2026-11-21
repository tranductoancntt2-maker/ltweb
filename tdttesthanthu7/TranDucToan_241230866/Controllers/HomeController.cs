using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TranDucToan_241230866.Models;

namespace TranDucToan_241230866.Controllers
{
    public class HomeController : Controller
    {
        public readonly QlhangHoaContext db;
        public HomeController(QlhangHoaContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var dsLoaiHang = await db.LoaiHangs.ToListAsync();
            ViewBag.LoaiHangs=dsLoaiHang;
            var dsHangHoa= await db.HangHoas.Where(hh=>hh.Gia>=100).ToListAsync();
            return View(dsHangHoa);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> LocHang(int maLoai)
        {
            var dsHangHoa=await db.HangHoas.Where(hh =>hh.MaLoai==maLoai && hh.Gia>=100).ToListAsync();
            return PartialView("_DanhSachHangHoa", dsHangHoa);
        }
        public async Task<IActionResult> Create()
        {
            var dsLoaiHang = await db.LoaiHangs.ToListAsync();
            ViewBag.LoaiHangs= dsLoaiHang;
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HangHoa hh)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hh);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var dsLoaiHang = await db.LoaiHangs.ToListAsync();
            ViewBag.LoaiHangs = dsLoaiHang;
            ViewBag.MaLoai = new SelectList(db.LoaiHangs, "MaLoai", "TenLoai");
            return View(hh);
        }
    }
}
