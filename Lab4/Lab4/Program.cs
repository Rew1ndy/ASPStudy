using Lab4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ILibraryService, LibraryService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
