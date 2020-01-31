using Microsoft.AspNetCore.Http;

namespace SocialNetwork.BusinessLogic.CloudinaryServices
{
    public interface ICloudinaryService
    {
        string ImageUpload(IFormFile file);
        string VideoUpload(IFormFile file);
    }
}