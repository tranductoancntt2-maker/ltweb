using Microsoft.AspNetCore.Mvc;
using tdtbuoi6demo.Models;

public class tdtMemberController : Controller
{
    // Dữ liệu lưu trong bộ nhớ RAM
    private static List<tdtMember> tdtMembers = new List<tdtMember>
    {
        new tdtMember
        {
            Id = 1,
            Name = "John Doe",
            Email = "john.doe@example.com",
            Phone = "123-456-7890",
            Address = "123 Main St",
            Gender = "Male"
        },
        new tdtMember
        {
            Id = 2,
            Name = "Jane Smith",
            Email = "jane.smith@example.com",
            Phone = "098-765-4321",
            Address = "456 Oak Ave",
            Gender = "Female"
        },
        new tdtMember
        {
            Id = 3,
            Name = "Alice Johnson",
            Email = "alice.johnson@example.com",
            Phone = "555-1234",
            Address = "789 Pine Rd",
            Gender = "Female"
        }
    };

    // GET: tdtMember
    public IActionResult Index()
    {
        return View(tdtMembers);
    }

    // GET: tdtMember/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tdtmember = tdtMembers.FirstOrDefault(m => m.Id == id);

        if (tdtmember == null)
        {
            return NotFound();
        }

        return View(tdtmember);
    }

    // GET: tdtMember/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: tdtMember/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(tdtMember tdtmember)
    {
        if (ModelState.IsValid)
        {
            // Tự tạo Id mới
            if (tdtMembers.Count > 0)
            {
                tdtmember.Id = tdtMembers.Max(x => x.Id) + 1;
            }
            else
            {
                tdtmember.Id = 1;
            }

            tdtMembers.Add(tdtmember);

            return RedirectToAction(nameof(Index));
        }

        return View(tdtmember);
    }

    // GET: tdtMember/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tdtmember = tdtMembers.FirstOrDefault(m => m.Id == id);

        if (tdtmember == null)
        {
            return NotFound();
        }

        return View(tdtmember);
    }

    // POST: tdtMember/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, tdtMember tdtmember)
    {
        if (id != tdtmember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var existingMember = tdtMembers.FirstOrDefault(m => m.Id == id);

            if (existingMember == null)
            {
                return NotFound();
            }

            // Cập nhật dữ liệu
            existingMember.Name = tdtmember.Name;
            existingMember.Email = tdtmember.Email;
            existingMember.Phone = tdtmember.Phone;
            existingMember.Address = tdtmember.Address;
            existingMember.Gender = tdtmember.Gender;

            return RedirectToAction(nameof(Index));
        }

        return View(tdtmember);
    }

    // GET: tdtMember/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tdtmember = tdtMembers.FirstOrDefault(m => m.Id == id);

        if (tdtmember == null)
        {
            return NotFound();
        }

        return View(tdtmember);
    }

    // POST: tdtMember/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tdtmember = tdtMembers.FirstOrDefault(m => m.Id == id);

        if (tdtmember == null)
        {
            return NotFound();
        }

        tdtMembers.Remove(tdtmember);

        return RedirectToAction(nameof(Index));
    }
}
