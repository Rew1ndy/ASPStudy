var builder = WebApplication.CreateBuilder(args);

// Додаємо контролери з поданнями
builder.Services.AddControllersWithViews();

// Додаємо сервіс для роботи з HttpClient для погоди
builder.Services.AddHttpClient<WeatherService>();

var app = builder.Build();

// Налаштовуємо маршрутизацію та статичні файли
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Маршрутизація за замовчуванням
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();