using Jues.Infrastructure.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Helpers
{
    /// <summary>
    /// 上传调用器助手
    /// </summary>
    public static class UploadInvokerHelper
    {
        /// <summary>
        /// 获取上传文件信息
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static UploadFileInfo GetUploadFileInfo(this IStorageInvoker uploadInvoker, IFormFile file)
        {
            UploadFileInfo uploadFileInfo = new UploadFileInfo();
            return uploadFileInfo;
        }
    }
}
