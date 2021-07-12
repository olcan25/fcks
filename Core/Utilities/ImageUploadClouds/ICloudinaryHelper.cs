using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.ImageUploadClouds
{
    public interface ICloudinaryHelper
    {
       string[] CreateAccount(IFormFile file);
       string DeleteAccount(string publicId);
       GetResourceResult GetUrlByPublicId(string publicId);
       bool IfCheckExistsPublicId(string publicId);
    }
}
