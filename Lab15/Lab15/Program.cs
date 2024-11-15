using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

var builder = WebApplication.CreateBuilder(args);

//////////////////      Web     ////////////////////

builder.Services.AddHostedService<WebsiteCheckerService>();

////////////////////////////////////////


//////////////////      Email     ////////////////////

//builder.Services.AddTransient<IEmailSender, EmailService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<EmailJob>();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    // Создаём задачу
    var jobKey = new JobKey("EmailJob");
    q.AddJob<EmailJob>(opts => opts.WithIdentity(jobKey));

    // Настраиваем триггер на выполнение каждые 10 sec
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("EmailJob-trigger")
        .WithSimpleSchedule(schedule =>
            schedule.WithIntervalInMinutes(10)
                    .RepeatForever())
    );
});

////////////////////////////////////////


//////////////////      Quartz    ////////////////////

builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(); 
builder.Services.AddMemoryCache(); 
builder.Services.AddSignalR(); 
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

////////////////////////////////////////


///////////////////   DB   /////////////////////

// Добавляем DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestDb")); // Используем InMemory DB для простоты

// Регистрация фоновой службы
builder.Services.AddHostedService<EmailNotificationService>();

////////////////////////////////////////



///////////////////   Weather   /////////////////////

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHostedService<WeatherBackgroundService>();

////////////////////////////////////////



///////////////////   SignalR   /////////////////////

builder.Services.AddSignalR();
builder.Services.AddHostedService<NotificationService>();

////////////////////////////////////////

var app = builder.Build();

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

app.MapGet("/", async (AppDbContext dbContext) =>
{
    // Для тестирования добавляем новую запись
    dbContext.Records.Add(new Record { Name = "Test Record" });
    await dbContext.SaveChangesAsync();
    return "Запись добавлена!";
});

app.MapHub<NotificationHub>("/notificationHub");

app.MapControllerRoute("default", "{controller=Notification}/{action=Index}");


app.Run();
