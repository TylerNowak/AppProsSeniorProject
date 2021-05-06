using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdeptsApp.Shared
{
    /// <summary>
    /// Validates the attached files before uploading through content type and extension
    /// </summary>
    public class FileValidationController
    {
        /// <summary>
        /// Determines if the file is an image
        /// </summary>
        /// <param name="iFormFile"></param>
        /// <returns>Boolean</returns>
        static public bool AttachmentContentValidation(IFormFile iFormFile)
        {
            return (iFormFile.ContentType == "image/jpg" || iFormFile.ContentType == "image/jpeg" || iFormFile.ContentType == "image/pjpeg");
        }

        /// <summary>
        /// Determines if the file extension is an image
        /// </summary>
        /// <param name="iFormFile"></param>
        /// <returns>Boolean</returns>
        static public bool AttachmentExtensionValidation(IFormFile iFormFile)
        {
            return (iFormFile.FileName.ToLower().Contains(".jpg") || iFormFile.FileName.ToLower().Contains(".jpeg") || iFormFile.FileName.ToLower().Contains(".pjpeg"));
        }
    }
}
