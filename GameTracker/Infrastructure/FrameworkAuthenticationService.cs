using GameTracker.Entity.Account;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace GameTracker.Infrastructure
{
    public class FrameworkAuthenticationService : Interfaces.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FrameworkAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SignInAuth(Guid id, string userNickname, UserStatus status, UserRole role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, userNickname),
                new Claim("Status", status.ToString()),
                new Claim(ClaimTypes.Role, role.ToString())
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            _httpContextAccessor.HttpContext.SignInAsync("CookieAuth", claimsPrincipal).GetAwaiter().GetResult();
        }

        public void SignOutAuth()
        {
            _httpContextAccessor.HttpContext.SignOutAsync("CookieAuth").GetAwaiter().GetResult();
        }
    }
}
