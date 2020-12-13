using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.UploadFileLocal
{
    public class UploadFilesResponseModel: ResponseModel
    {
        public List<string> FileNames { get; set; }
        public int FailCount { get; set; }
        public int SuccessCount { get; set; }
    }
}
