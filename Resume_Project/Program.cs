using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Resume_Project.Data;
using Resume_Project.Data.Repositories;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

#region DbContext

builder.Services.AddDbContext<MyResumeContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("MyResumeConnection"))
); 


#endregion

#region IOC

builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Authentication

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login";
    option.LogoutPath = "/Logout";
    option.ExpireTimeSpan = TimeSpan.FromHours(1);
});

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        if (!context.User.Identity!.IsAuthenticated)
        {
            context.Response.Redirect("/Login");
        }
        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")!))
        {
            context.Response.Redirect("/Login");
        }
    }
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
