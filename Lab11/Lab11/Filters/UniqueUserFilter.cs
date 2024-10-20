using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class UniqueUserFilter : IActionFilter
    {
        private static HashSet<string> uniqueUsers = new HashSet<string>();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Отримання IP-адреси користувача
            var userIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (!uniqueUsers.Contains(userIp))
            {
                uniqueUsers.Add(userIp);
                File.AppendAllText("userCount.txt", $"New user: {userIp}, Total users: {uniqueUsers.Count}\n");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }
    }
}
