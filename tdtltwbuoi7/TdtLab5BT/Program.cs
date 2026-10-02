var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Hien thi loi tieng Viet khi nguoi dung nhap chu vao truong so.
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        fieldName => $"{fieldName} phai la so. Vui long nhap dung dinh dang.");

    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
        value => $"Gia tri \"{value}\" khong hop le.");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
