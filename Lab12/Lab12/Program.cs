using Lab12.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lab12.Data;
using Lab12.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<UserDBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDBContext") ?? throw new InvalidOperationException("Connection string 'UserDBContext' not found.")));

builder.Services.AddDbContext<UserDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDBContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern:"{controller=UserDB}/{action=Index}/{id?}");

app.Run();