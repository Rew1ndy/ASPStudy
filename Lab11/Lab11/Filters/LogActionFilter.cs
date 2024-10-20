using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Логіка, яка виконується перед виконанням методу дії
            var actionName = context.ActionDescriptor.DisplayName;
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Запис до файлу
            File.AppendAllText("log.txt", $"Action: {actionName}, Time: {currentTime}\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }
    }
}
