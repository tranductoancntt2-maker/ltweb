using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TdtTH2Lab4.Models;

namespace TdtTH2Lab4.Controllers
{
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _env;

        // Dùng static để danh sách sinh viên không bị reset sau mỗi HTTP Request
        private static List<Student> listStudents = new List<Student>()
        {
            new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular = true,
                Address = "A1-2018", Email = "nam@gmail.com", DateOfBorth = new DateTime(2003, 5, 12), Score = 8.5 },
            new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                Gender = Gender.Female, IsRegular = true,
                Address = "A1-2019", Email = "tu@gmail.com", DateOfBorth = new DateTime(2003, 8, 20), Score = 7.0 },
            new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                Gender = Gender.Male, IsRegular = false,
                Address = "A1-2020", Email = "phong@gmail.com", DateOfBorth = new DateTime(2002, 11, 15), Score = 6.5 },
            new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                Gender = Gender.Female, IsRegular = false,
                Address = "A1-2021", Email = "mai@gmail.com", DateOfBorth = new DateTime(2003, 1, 30), Score = 9.0 }
        };

        public StudentController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Action hiển thị danh sách sinh viên
        public IActionResult Index()
        {
            return View(listStudents);
        }

        // Action GET: Hiển thị form tạo mới sinh viên
        [HttpGet]
        public IActionResult Create()
        {
            // Lấy danh sách Gender cho radio button
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            // Lấy danh sách Branch cho select-option
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = ((int)Branch.IT).ToString() },
                new SelectListItem { Text = "BE", Value = ((int)Branch.BE).ToString() },
                new SelectListItem { Text = "CE", Value = ((int)Branch.CE).ToString() },
                new SelectListItem { Text = "EE", Value = ((int)Branch.EE).ToString() }
            };

            return View();
        }

        // Action POST: Xử lý thêm sinh viên và upload ảnh đại diện (Phần 9 + Bài TH3 Validation)
        [HttpPost]
        public async Task<IActionResult> Create(Student s, IFormFile? avatarFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý upload ảnh đại diện nếu người dùng có chọn file
                if (avatarFile != null && avatarFile.Length > 0)
                {
                    string uploadFolder = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(avatarFile.FileName);
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await avatarFile.CopyToAsync(fileStream);
                    }

                    s.AvatarUrl = "/images/" + fileName;
                }

                // Gán Id tự tăng tiếp theo
                s.Id = listStudents.Any() ? listStudents.Max(x => x.Id) + 1 : 101;
                listStudents.Add(s);

                // Trả về view Index cùng danh sách sinh viên đã cập nhật
                return View("Index", listStudents);
            }

            // Nếu dữ liệu không hợp lệ (ModelState.IsValid == false), tải lại ViewBag và hiển thị lại Form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = ((int)Branch.IT).ToString() },
                new SelectListItem { Text = "BE", Value = ((int)Branch.BE).ToString() },
                new SelectListItem { Text = "CE", Value = ((int)Branch.CE).ToString() },
                new SelectListItem { Text = "EE", Value = ((int)Branch.EE).ToString() }
            };

            return View(s);
        }
    }
}
