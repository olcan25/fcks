using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileUpload
{
    public interface IFileUploadHelper
    {

        string Upload(IFormFile file);
    }
}
