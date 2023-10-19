using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;

namespace Jues.Infrastructure.Files
{
    /// <summary>
    /// 无存储上传调用器
    /// </summary>
    public sealed class NonStorageInvoker : IStorageInvoker
    {
        public string GetMD5(string path)
        {
            throw new HostFriendlyException($"未发现存储设备");
        }

        public FileStream Open(string path)
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync(IFormFile file, string path)
        {
            throw new HostFriendlyException($"未发现存储设备");
        }
    }
}
