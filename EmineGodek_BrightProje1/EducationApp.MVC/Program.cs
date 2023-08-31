using AspNetCoreHero.ToastNotification;
using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete.EfCore.Repositories;
using EducationApp.Data.Concrete.EFCore.Contexts;
using EducationApp.Data.Concrete.EFCore.Repositories;
using EducationApp.Entity.Concrete;
using EducationApp.MVC.EmailServices.Abstract;
using EducationApp.MVC.EmailServices.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EducationAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
	.AddEntityFrameworkStores<EducationAppContext>()
	.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = true;

	options.Lockout.MaxFailedAccessAttempts = 3; 
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

	options.User.RequireUniqueEmail = true;

	options.SignIn.RequireConfirmedEmail = false;
	options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/account/login";
	options.LogoutPath = "/account/logout";
	options.AccessDeniedPath = "/account/accessdenied";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
	options.SlidingExpiration = true;
	options.Cookie = new CookieBuilder
	{
		HttpOnly = true,
		SameSite = SameSiteMode.Strict,
		Name = "EducationApp.Security.Cookie"
	};
});

builder.Services.AddScoped<IEmailSender, SmtpEmailSender>(option => new SmtpEmailSender
(
	builder.Configuration["EmailSender:Host"],
	builder.Configuration.GetValue<int>("EmailSender:Port"),
	builder.Configuration["EmailSender:UserName"],
	builder.Configuration["EmailSender:Password"],
	builder.Configuration.GetValue<bool>("EmailSender:EnableSsl")
));

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICartService, CartManager>();
builder.Services.AddScoped<ICartItemService, CartItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IProductRepository, EfCoreProductRepository>();
builder.Services.AddScoped<IInstructorRepository, EfCoreInstructorRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "productscategory",
    pattern: "kategoriler/{categoryurl?}",
    defaults: new { controller = "EducationApp", action = "ProductList" }
    );

app.MapControllerRoute(
    name: "products",
    pattern: "egitimler/{producturl?}",
    defaults: new { controller = "EducationApp", action = "InstructorList" }
    );

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
