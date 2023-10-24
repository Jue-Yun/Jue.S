using Jues.Base.Cores.Jwts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Jwt.Attributes;
using Suyaa.Hosting.Jwt.Dependency;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;
using Jues.Infrastructure.Helpers;
using Jues.Infrastructure.Jwt;
using Jues.Infrastructure.Files;
using Jues.Base.Entities.Files;
using Jues.Base.Cores.Files.Dto;
using Jues.Base.Cores.Files;
using Suyaa.Hosting.Kernel.Dependency;

namespace Jues.Base.Apps.Files
{
    /// <summary>
    /// 文件
    /// </summary>
    [JuesJwtAuthorize]
    public sealed class FileServiceApp : ServiceApp
    {
        #region DI注入

        private readonly IStorageInvoker _storageInvoker;
        private readonly IObjectMapper _objectMapper;
        private readonly FileStorageCore _fileStorageCore;

        /// <summary>
        /// 用户
        /// </summary>
        public FileServiceApp(
            IStorageInvoker storageInvoker,
            IObjectMapper objectMapper,
            FileStorageCore fileStorageCore
            )
        {
            _storageInvoker = storageInvoker;
            _objectMapper = objectMapper;
            _fileStorageCore = fileStorageCore;
        }

        #endregion

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public async Task<FileStorageOutput> Upload(IFormFile? file)
        {
            if (file is null) throw new UserFriendlyException($"未发现上传文件");
            // 获取当前时间
            var now = sy.Time.Now;
            FileStorage fileStorage = new FileStorage()
            {
                MimeType = file.ContentType,
                Name = file.FileName,
                Size = file.Length,
            };
            fileStorage.Path = $"{now.Year}/{now.Month}/{now.Day}/{fileStorage.Id}.file";
            // 保存文件
            await _storageInvoker.WriteAsync(file, fileStorage.Path);
            // 设置路径
            fileStorage.Md5 = _storageInvoker.GetMD5(fileStorage.Path);
            // 保存文件存储信息
            await _fileStorageCore.InsertData(fileStorage);
            // 返回结果
            return _objectMapper.Map<FileStorageOutput>(fileStorage);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="files">文件集合</param>
        /// <returns></returns>
        public async Task<List<FileStorageOutput>> UploadList([FromForm] IFormFileCollection files)
        {
            if (!files.Any()) throw new UserFriendlyException($"未发现上传文件");
            List<FileStorageOutput> list = new List<FileStorageOutput>();
            foreach (var file in files)
            {
                if (file is null) continue;
                var output = await Upload(file);
                list.Add(output);
            }
            return list;
        }
    }
}
