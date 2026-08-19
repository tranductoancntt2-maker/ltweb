var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Toàn!");
app.MapGet("/a", () => "Bà tôi từng nói: Bước đi trên thiên đạo, ngươi sẽ thống trị tất cả!");


app.Run();
