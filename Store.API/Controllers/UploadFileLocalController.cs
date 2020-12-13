using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.API.Helpers;
using Store.API.Models.UploadFileLocal;

namespace Store.API.Controllers
{
    [AllowAnonymous]
    public class UploadFileLocalController : BaseController
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;
        private readonly ILogger<UploadFileLocalController> _logger;

        public UploadFileLocalController(
            IConfiguration configuration, 
            IHostingEnvironment env,
            ILogger<UploadFileLocalController> logger)
        {
            this.configuration = configuration;
            this.env = env;
            _logger = logger;
        }

        [HttpPost("Uploads")]
        public async Task<UploadFilesResponseModel> Uploads([FromForm] UploadFileModel model)
        {
            _logger.LogError("Start Uploading", this.GetType().Name);
            var response = new UploadFilesResponseModel
            {
                Result = true,
                FileNames = new List<string>(),
            };

            if (!string.IsNullOrEmpty(model.ObjectType))
            {
                _logger.LogError($"Files: {model.Files.Count}", this.GetType().Name);

                foreach (var file in model.Files)
                {
                    if (file.Length > 0)
                    {   
                        var guid = Guid.NewGuid().ToString();
                        var fileName = guid + Path.GetExtension(file.FileName);

                        var fileType = ImageHelper.IsImage(fileName) ? "images" : "documents";

                        // Create directory if not Existed
                        var directory = Path.Combine(env.WebRootPath, "uploads");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        directory = Path.Combine(directory, fileType);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        directory = Path.Combine(directory, model.ObjectType);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        string filePath = Path.Combine(directory, fileName);

                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);

                            var domain = Request.Scheme + "://" + Request.Host;
                            var absoluteUrl = $"{domain}/uploads/{fileType}/{model.ObjectType}/{fileName}";
                            response.FileNames.Add(absoluteUrl);
                        }

                        response.SuccessCount++;
                    }
                    else
                    {
                        response.FailCount++;
                    }
                }
            }
            else
            {
                response.Result = false;
                response.Messages.Add("ObjectType is required");
                _logger.LogError("ObjectType is required", this.GetType().Name);
            }

            return response;
        }
    }
}