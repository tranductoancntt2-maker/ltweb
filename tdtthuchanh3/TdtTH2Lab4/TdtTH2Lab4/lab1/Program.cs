using Microsoft.EntityFrameworkCore;
using TdtTH2Lab4.Data;
using TdtTH2Lab4.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký SchoolContext là một DbContext của ứng dụng
var connectionString = builder.Configuration.GetConnectionString("SchoolContext")
    ?? "Server=.;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(connectionString));

// Thêm dịch vụ Razor Pages và Controllers with Views (MVC)
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Khởi tạo cơ sở dữ liệu và nạp dữ liệu mẫu
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Cho phép phục vụ file tĩnh và ảnh upload trong wwwroot/images
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// --- Phần 8: Cấu hình Route cho StudentController ---
app.MapControllerRoute(
    name: "student_list",
    pattern: "Admin/Student/List",
    defaults: new { controller = "Student", action = "Index" });

app.MapControllerRoute(
    name: "student_add",
    pattern: "Admin/Student/Add",
    defaults: new { controller = "Student", action = "Create" });

// Route mặc định điều hướng vào StudentController/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
