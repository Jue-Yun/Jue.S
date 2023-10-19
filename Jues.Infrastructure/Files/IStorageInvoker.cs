using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Files
{
    /// <summary>
    /// 上传调用器
    /// </summary>
    public interface IStorageInvoker
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task WriteAsync(IFormFile file, string path);

        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        string GetMD5(string path);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        FileStream Open(string path);

    }
}
