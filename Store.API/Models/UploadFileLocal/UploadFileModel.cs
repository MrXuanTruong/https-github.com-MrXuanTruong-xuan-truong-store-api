using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.UploadFileLocal
{
    public class UploadFileModel
    {
        public string ObjectType { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
