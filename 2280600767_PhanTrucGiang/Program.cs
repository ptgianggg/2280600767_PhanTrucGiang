using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//
builder.Services.AddDbContext<GiangDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChuoiKetNoi")));
builder.Services.AddScoped<IMonAnRepository, MonAnRepository>();
builder.Services.AddScoped<ILoaiMonAnRepository, LoaiMonAnRepository>();



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
