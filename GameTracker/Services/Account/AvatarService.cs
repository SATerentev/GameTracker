using GameTracker.Interfaces;
using GameTracker.Interfaces.Account;

namespace GameTracker.Services.Account
{
    public class AvatarService : IAvatarService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserAuthService _userAuthService;
        private readonly IUserRepository _userRepository;

        public AvatarService(IUserAuthService userAuthService, IUserRepository userRepository)
        {
            _userAuthService = userAuthService;
            _userRepository = userRepository;
        }

        public List<string> GetPathsDefaultAvatars()
        {
            var path = Path.Combine(_env.WebRootPath, "avatars", "default");
            var paths = Directory.GetFiles(path)
                .Where(f => f.EndsWith(".png") || f.EndsWith(".jpeg") || f.EndsWith(".jpg"))
                .Select(f => "\\avatars\\default" + Path.GetFileName(f))
                .OrderBy(x => x)
                .ToList();

            return paths;
        }

        public bool TryUploadUserAvatar(Guid userId, IFormFile file, out string errorMessage)
        {
            errorMessage = string.Empty;
            var folderPath = Path.Combine(_env.WebRootPath, "avatars", "default");
            var allowedTypes = new[] { "image/png", "image/jpg", "image/jpeg" };
            var user = _userAuthService.GetUser(userId);

            if (file == null) { errorMessage = "Файл отсутствует"; return false; }
            if (file.Length >= 5 * 1024 * 1024) { errorMessage = "Файл слишком большой"; return false; }
            if (file.Length == 0) { errorMessage = "Файл пустой"; return false; }
            if (!allowedTypes.Contains(file.ContentType.ToLower())) { errorMessage = "Только png, jpg или jpeg"; return false; }

            var filePath = Path.Combine(folderPath, $"{userId}.jpg");

            file.CopyTo(File.Create(filePath));
            user.ChangeAvatar(filePath);
            _userRepository.UpdateUser(user);

            return true;
        }

        public void SetDefaultAvatar(Guid userId, string defaultAvatarPath)
        {
            var user = _userAuthService.GetUser(userId);

            user.ChangeAvatar(defaultAvatarPath);
            _userRepository.UpdateUser(user);

            // Чувствую, что хуйня метод, надо будет переделать потом
        }
    }
}
