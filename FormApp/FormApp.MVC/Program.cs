using FormApp.Business.Abstract;
using FormApp.Business.Concrete;
using FormApp.Data.Abstract;
using FormApp.Data.Concrete.EfCore;
using FormApp.Data.Concrete.EfCore.Context;
using FormApp.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromHours(1); });

builder.Services.AddDbContext<FormAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<FormAppContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".FormApp.Security.Cookie"
    };
});
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITestFormService, TestFormManager>();
builder.Services.AddScoped<ITestFormFieldService, TestFormFieldManager>();

builder.Services.AddScoped<ITestFormRepository, EfCoreTestFormRepository>();
builder.Services.AddScoped<ITestFormFieldRepository, EfCoreTestFormFieldRepository>();

var app = builder.Build();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Forms}/{action=Index}/{id?}");

app.Run();
