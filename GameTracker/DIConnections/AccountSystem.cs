using GameTracker.Infrastructure;
using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;
using GameTracker.Services;
using GameTracker.Services.Account;

namespace GameTracker.DIConnections
{
    public static class AccountSystem
    {
        public static void ConnectSystem(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserAuthService, UserAuthService>();
            builder.Services.AddScoped<IUpdateProfileService, UpdateProfileService>();
            builder.Services.AddScoped<IUserStatusService, UserStatusService>();
            builder.Services.AddScoped<IRegisterService, RegisterService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthenticationService, FrameworkAuthenticationService>();
            builder.Services.AddScoped<IAccountVerificationService, AccountVerificationService>();
        }
    }
}
