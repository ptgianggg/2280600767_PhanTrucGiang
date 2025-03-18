using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//
builder.Services.AddDbContext<GiangDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChuoiKetNoi")));




builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<GiangDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.LogoutPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Admin",pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
