using Serilog;
using Serilog.Exceptions;
using System.Net;
using Serilog.Events;
using Serilog.Sinks.EmailPickup;

var builder = WebApplication.CreateBuilder(args);

// Logger:
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    //.WriteTo.Seq("http://localhost:5341")
    .WriteTo.EmailPickup(
        fromEmail: "doNotReply@domain.com", 
        toEmail: "bogdin200056@gmail.com", 
        pickupDirectory: @"C:\email-pickup",
        subject: "There is something wrong with consoleapp", 
        fileExtension: ".eml", 
        restrictedToMinimumLevel: LogEventLevel.Error
    )
    .CreateLogger();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
