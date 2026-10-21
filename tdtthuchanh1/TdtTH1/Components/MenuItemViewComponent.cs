using Microsoft.AspNetCore.Mvc;

namespace TdtTH1.Components
{
    public class MenuItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var items = new List<MenuLink>
            {
                new MenuLink { Title = "Trang chủ", Url = "/Home/Index" },
                new MenuLink { Title = "Danh sách sinh viên", Url = "/Admin/Student/List" },
                new MenuLink { Title = "Thêm sinh viên", Url = "/Admin/Student/Add" }
            };

            return View(items);
        }
    }

    public class MenuLink
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
