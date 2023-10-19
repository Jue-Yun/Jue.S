using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Files
{
    /// <summary>
    /// 目录存储上传调用器
    /// </summary>
    public sealed class FolderStorageInvoker : IStorageInvoker
    {
        // 存储地址
        private readonly string _path;

        /// <summary>
        /// 目录存储上传调用器
        /// </summary>
        /// <param name="path"></param>
        public FolderStorageInvoker(string path)
        {
            _path = path;
        }

        /// <summary>
        /// 获取MD5
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMD5(string path)
        {
            string filePath = sy.IO.CombinePath(_path, path);
            return sy.IO.GetMD5(filePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FileStream Open(string path)
        {
            // 拼接完整路径
            string filePath = sy.IO.CombinePath(_path, path);
            return new FileStream(filePath,FileMode.Open,FileAccess.Read,FileShare.Read);
        }

        /// <summary>
        /// 写入上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task WriteAsync(IFormFile file, string path)
        {
            // 拼接完整路径
            string filePath = sy.IO.CombinePath(_path, path);
            // 自动创建目录
            string fileFolder = sy.IO.GetFolderPath(filePath);
            sy.IO.CreateFolder(fileFolder);
            // 保存文件
            using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fs);
            fs.Close();
        }
    }
}
