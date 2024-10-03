namespace Lab5.Middleware
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw; // Пробрасываем исключение дальше, чтобы оно дошло до стандартной обработки ошибок
            }
        }

        private void LogException(Exception ex)
        {
            var logFilePath = "logs/exceptions.log";
            var logMessage = $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n";
            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
            File.AppendAllText(logFilePath, logMessage);
        }
    }

    public static class ExceptionLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggingMiddleware>();
        }
    }

}
