using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Cấu hình Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ✅ Thêm Controllers với Views
builder.Services.AddControllersWithViews();

// ✅ Kết nối Database
builder.Services.AddDbContext<GiangDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChuoiKetNoi")));

// ✅ Cấu hình Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<GiangDbContext>();

// ✅ Cấu hình Cookie Authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// ✅ Cấu hình Razor Pages
builder.Services.AddRazorPages();

// ✅ Inject Repository vào DI Container
builder.Services.AddScoped<IMonAnRepository, MonAnRepository>();
builder.Services.AddScoped<ILoaiMonAnRepository, LoaiMonAnRepository>();

var app = builder.Build();

// ✅ Cấu hình lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ✅ Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ✅ Định tuyến Controller
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ Cấu hình Razor Pages (cho Identity)
app.MapRazorPages();

app.Run();
