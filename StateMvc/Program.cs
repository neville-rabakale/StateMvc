using StateMvc.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DataService>();
builder.Services.AddSession();
builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseSession();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());

app.Run();