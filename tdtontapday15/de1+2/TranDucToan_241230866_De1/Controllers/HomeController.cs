using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TranDucToan_241230866_De1.Models;

namespace TranDucToan_241230866_De1.Controllers
{
    public class HomeController : Controller
    {
        public readonly QltaiSanContext db;
        public HomeController(QltaiSanContext db)
        {
            this.db = db;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.LoaiTaiSans = await db.LoaiTaiSans.ToListAsync();
            var dsTaiSan = await db.TaiSans.Where(ts => ts.NguyenGia >= 20).ToListAsync();
            return View(dsTaiSan);
        }
        public async Task<IActionResult> LocTaiSan(int maLoai)
        {
            var dsTaiSan=await db.TaiSans.Where(ts=>ts.MaLoai==maLoai && ts.NguyenGia>=20).ToListAsync();
            return PartialView("_DanhSachTaiSan", dsTaiSan);
        }
        public async Task<IActionResult> Create()
        {
            var dsLoaiTaiSan = await db.LoaiTaiSans.ToListAsync();
            ViewBag.LoaiTaiSans=dsLoaiTaiSan;
            ViewBag.MaLoai = new SelectList(dsLoaiTaiSan, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaiSan ts)
        {
            if (ModelState.IsValid)
            {
                db.TaiSans.Add(ts);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var dsLoaiTaiSan = await db.LoaiTaiSans.ToListAsync();
            ViewBag.LoaiTaiSans = dsLoaiTaiSan;
            ViewBag.MaLoai = new SelectList(dsLoaiTaiSan, "MaLoai", "TenLoai");
            return View(ts);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var ts = await db.TaiSans.AsNoTracking().FirstOrDefaultAsync(t => t.MaTs == id);
            if (ts == null) return NotFound();
            var ds = await NapLoaiTaiSanAsync();
            ViewBag.MaLoai = new SelectList(ds, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaiSan model)
        {
            if(id!=model.MaTs) return NotFound();
            if (ModelState.IsValid)
            {
                var ts = await db.TaiSans.FindAsync(id);
                if(ts == null) return NotFound();
                ts.MaLoai=model.MaLoai;
                ts.TenTs=model.TenTs;
                ts.NguyenGia=model.NguyenGia;
                ts.Anh=model.Anh;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var ds = await NapLoaiTaiSanAsync();
            ViewBag.MaLoai = new SelectList(ds, "MaLoai", "TenLoai", model.MaLoai);
            return View(model);
        }
        private async Task<List<LoaiTaiSan>> NapLoaiTaiSanAsync()
        {
            var ds=await db.LoaiTaiSans.AsNoTracking().ToListAsync();
            ViewBag.LoaiTaiSans = ds;
            return ds;
        }
    }
}
