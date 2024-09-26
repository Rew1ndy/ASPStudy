using Lab3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();