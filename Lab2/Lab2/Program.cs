using Lab2;
using Microsoft.AspNetCore.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("config.json", optional: false, reloadOnChange: true);
                config.AddXmlFile("config.xml", optional: false, reloadOnChange: true);
                config.AddIniFile("config.ini", optional: false, reloadOnChange: true);

                config.AddJsonFile("myinfo.json", optional: false, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}