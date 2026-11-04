using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Tự động chuyển hướng sang trang Danh sách sinh viên
            return Redirect("/Admin/Student/List");
        }
    }
}
