using Microsoft.AspNetCore.Http;
using Suyaa.Hosting.Common.Exceptions;

namespace Jues.Infrastructure.Files
{
    /// <summary>
    /// 无存储上传调用器
    /// </summary>
    public sealed class NonStorageInvoker : IStorageInvoker
    {
        /// <summary>
        /// 获取文件MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public string GetMD5(string path)
        {
            throw new UserFriendlyException($"未发现存储设备");
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FileStream Open(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public Task WriteAsync(IFormFile file, string path)
        {
            throw new UserFriendlyException($"未发现存储设备");
        }
    }
}
