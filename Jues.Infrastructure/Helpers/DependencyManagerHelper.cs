using Jues.Configure;
using Suyaa.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;
using Jues.Infrastructure.Files;
using Jues.Infrastructure.Jwt;
using Suyaa.Hosting.Jwt.Helpers;
using Suyaa.Hosting.Jwt.Options;

namespace Jues.Infrastructure.Helpers
{
    /// <summary>
    /// 依赖助手
    /// </summary>
    public static class DependencyManagerHelper
    {
        /// <summary>
        /// 添加上传调用器
        /// </summary>
        /// <param name="dependency"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static IDependencyManager AddFileStorage(this IDependencyManager dependency, StorageOption? option)
        {
            // 没有配置则添加无存储调用器
            if (option is null)
            {
                dependency.Register<IStorageInvoker>(new NonStorageInvoker());
                return dependency;
            }
            // 创建调用器
            IStorageInvoker uploadInvoker = option.Type.ToLower() switch
            {
                "folder" => new FolderStorageInvoker(sy.IO.GetFullPath(option.Path)),
                "" => new NonStorageInvoker(),
                _ => throw new HostException($"不支持的存储类型'{option.Type}'。"),
            };
            // 添加依赖注入
            dependency.Register<IStorageInvoker>(uploadInvoker);
            return dependency;
        }

        /// <summary>
        /// 添加自定义Jwt支持
        /// </summary>
        /// <param name="dependency"></param>
        /// <param name="jwtOption"></param>
        /// <returns></returns>
        public static IDependencyManager AddJuesJwt(this IDependencyManager dependency, Configure.JwtOption? jwtOption)
        {
            // 添加Jwt支持
            var option = new Suyaa.Hosting.Jwt.Options.JwtOption();
            if (jwtOption != null)
            {
                option.TokenName = jwtOption.Header;
                option.TokenKey = jwtOption.Key;
            }
            dependency.AddJwt<JuesJwtDataProvider, JuesJwtData>(option);
            dependency.Register<JuesJwtManager, JuesJwtManager>(Lifetimes.Transient);
            return dependency;
        }
    }
}
