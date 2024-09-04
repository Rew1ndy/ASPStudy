//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

////app.MapGet("/", () => "Hello World!");
//app.UseWelcomePage();

//app.Run();


var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры
builder.Services.AddControllers();

var app = builder.Build();

// Настраиваем маршрутизацию для контроллеров
app.MapControllers();

app.Run();
