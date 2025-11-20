using Microsoft.Extensions.FileProviders;

namespace GameTracker.Interfaces.Account
{
    public interface IAvatarService
    {
        List<string> GetPathsDefaultAvatars();
        bool TryUploadUserAvatar(Guid userId, IFormFile file, out string errorMessage);
        void SetDefaultAvatar(Guid userId, string defaultAvatarPath);
    }
}
