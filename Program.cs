using Winterra.DataContexts;
using Winterra.Infrastructure.Middleware;
using Winterra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AccountDataAccess>();
builder.Services.AddScoped<ContentDataAccess>();
builder.Services.AddScoped<ContentService>();


// Add Services
builder.Services.AddScoped<Winterra.Areas.Admin.Services.AccountService>();
builder.Services.AddScoped<Winterra.Areas.Admin.Services.ContentService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication("Auth")
    .AddCookie("Auth", options => { 
        options.Cookie.Name = "Auth"; 
        options.LoginPath = "/Admin/Account/Login";  
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.AccessDeniedPath = "/Forbidden/";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Global exception handling should be as early as possible
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
