using Microsoft.EntityFrameworkCore;
using Practice1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:DefaultConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "Hello World!");
var context = app.Services.CreateScope().ServiceProvider
.GetRequiredService<DataContext>();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});
app.Run();