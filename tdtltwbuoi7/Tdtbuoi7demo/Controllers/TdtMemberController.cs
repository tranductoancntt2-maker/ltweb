using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tdtbuoi7demo.Models;

namespace Tdtbuoi7demo.Controllers
{
    public class TdtMemberController : Controller
    {
        private static List<Models.tdtMember> tdtmembers = new List<Models.tdtMember>();
        // GET: TdtMemberController
        public ActionResult Index()
        {
            return View(tdtmembers);
        }

        // GET: TdtMemberController/Details/5
        public ActionResult Details(int id)
        {
            var member = tdtmembers.FirstOrDefault(m => m.Id == id);
            return View(member);
        }

        // GET: TdtMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TdtMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tdtMember tdtMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tdtMember);
                }
                tdtMember.Id = tdtmembers.Count > 0 ? tdtmembers.Max(m => m.Id) + 1 : 1;
                tdtmembers.Add(tdtMember);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TdtMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TdtMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TdtMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TdtMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
