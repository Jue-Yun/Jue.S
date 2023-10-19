using Jues.Base.Cores.Files;
using Jues.Base.Cores.Jwts;
using Jues.Infrastructure.Common;
using Jues.Infrastructure.Files;
using Jues.Infrastructure.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Jwt.Attributes;
using Suyaa.Hosting.Jwt.Dependency;
using Suyaa.Hosting.Kernel.Attributes;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Apps.Files
{
    /// <summary>
    /// 文件存储
    /// </summary>
    public sealed class FileStorageServiceApp : ServiceApp
    {
        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStorageInvoker _storageInvoker;
        private readonly JuesJwtManager _juesJwtManager;
        private readonly JwtInfoCore _jwtInfoCore;
        private readonly FileStorageCore _fileStorageCore;

        /// <summary>
        /// 用户
        /// </summary>
        public FileStorageServiceApp(
            IDependencyManager dependencyManager,
            IHttpContextAccessor httpContextAccessor,
            IStorageInvoker storageInvoker,
            JuesJwtManager juesJwtManager,
            JwtInfoCore jwtInfoCore,
            FileStorageCore fileStorageCore
            )
        {
            _dependencyManager = dependencyManager;
            _httpContextAccessor = httpContextAccessor;
            _storageInvoker = storageInvoker;
            _juesJwtManager = juesJwtManager;
            _jwtInfoCore = jwtInfoCore;
            _fileStorageCore = fileStorageCore;
        }

        #endregion

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [NotWrapper]
        public async Task<IActionResult> Get(string id)
        {
            var respose = _httpContextAccessor.HttpContext?.Response;
            var data = await _fileStorageCore.GetDataById(id);
            if (data is null || respose is null)
            {
                return new ContentResult() { Content = $"文件Id'{id}'未找到", ContentType = MimeTypes.TEXT, StatusCode = 500 };
            }
            try
            {
                // 打开文件
                var fs = _storageInvoker.Open(data.Path);
                // 文件名必须编码，否则会有特殊字符(如中文)无法在此下载。
                string encodeFilename = System.Web.HttpUtility.UrlEncode(data.Name, Encoding.GetEncoding("UTF-8"));
                // 添加头部信息
                respose.Headers.ContentLength = fs.Length;
                respose.Headers.Add("Access-Control-Expose-Headers", "*");
                respose.Headers.Add("Content-Disposition", "attachment; filename=" + encodeFilename);
                // 返回文件流
                return new FileStreamResult(fs, data.MimeType);
            }
            catch (Exception ex)
            {
                return new ContentResult() { Content = $"文件处理发生异常：{ex.Message}", ContentType = MimeTypes.TEXT, StatusCode = 500 };
            }
        }
    }
}
