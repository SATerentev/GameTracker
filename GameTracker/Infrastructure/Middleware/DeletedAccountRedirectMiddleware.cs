using GameTracker.Entity.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameTracker.Infrastructure.Middleware
{
    public class DeletedAccountRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public DeletedAccountRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var user = context.User;

            if (user.Identity.IsAuthenticated)
            {
                if (user.FindFirstValue("Status").ToString() == UserStatus.Deleted.ToString())
                {
                    if (context.Request.Path.StartsWithSegments("/AccountRecovery") ||
                        context.Request.Path.StartsWithSegments("/Auth/Logout") ||
                        context.Request.Path.Value.EndsWith(".css") ||
                        context.Request.Path.Value.EndsWith(".js") ||
                        context.Request.Path.Value.EndsWith(".png") ||
                        context.Request.Path.Value.EndsWith(".jpg") ||
                        context.Request.Path.Value.EndsWith(".ico"))
                        return _next(context);

                    context.Response.Redirect("/AccountRecovery");
                    return Task.CompletedTask;
                }
            }

            return _next(context);
        }
    }
}
