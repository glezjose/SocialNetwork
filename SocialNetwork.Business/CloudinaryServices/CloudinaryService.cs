using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace SocialNetwork.BusinessLogic.CloudinaryServices
{
    public class CloudinaryService : ICloudinaryService
    {
        private Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary ?? throw new ArgumentNullException(nameof(cloudinary));
        }
        public string ImageUpload(IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream)
                };

                return cloudinary.Upload(uploadParams).SecureUri.ToString();
            }
        }

        public string VideoUpload(IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                VideoUploadParams uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                };

                return cloudinary.Upload(uploadParams).SecureUri.ToString();
            }
        }

    }
}

