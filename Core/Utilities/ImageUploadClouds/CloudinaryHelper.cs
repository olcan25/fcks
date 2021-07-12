using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.ImageUploadClouds
{
    public class CloudinaryHelper : ICloudinaryHelper
    {
        public IConfiguration Configuration { get; set; }
        private readonly CloudinarySettings _cloudinarySettings;
        internal Cloudinary _cloudinary;

        public CloudinaryHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(
                _cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }


        public string[] CreateAccount(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();                 //  3.

            if ( file != null)                                        //  4.
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);    //  5.
                }
                string[] data = new[]
                {
                    uploadResult.Url.ToString(), uploadResult.PublicId
                };

                return data;
            }

            return new[] { "", "" };

        }

        public string DeleteAccount(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            return _cloudinary.Destroy(deleteParams).Result;
        }

        public GetResourceResult GetUrlByPublicId(string publicId)
        {
            var value = _cloudinary.GetResource(publicId);
            return value;
        }

        public bool IfCheckExistsPublicId(string publicId)
        {
            var result = _cloudinary.GetResource(publicId).StatusCode;
            if (result == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
