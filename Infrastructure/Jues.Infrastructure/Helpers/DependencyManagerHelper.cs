using Jues.Infrastructure.Files;
using Jues.Infrastructure.Jwt;
using Suyaa.Hosting.Jwt.Helpers;
using Suyaa.Hosting.Infrastructure.Exceptions;
using Jues.Infrastructure.Configures;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.Common.DependencyInjection;

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
        public static IDependencyManager AddFileStorage(this IDependencyManager dependency, StorageConfig? option)
        {
            // 没有配置则添加无存储调用器
            if (option is null)
            {
                dependency.RegisterInstance<IStorageInvoker>(new NonStorageInvoker());
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
            dependency.RegisterInstance<IStorageInvoker>(uploadInvoker);
            return dependency;
        }

        /// <summary>
        /// 添加自定义Jwt支持
        /// </summary>
        /// <param name="dependency"></param>
        /// <returns></returns>
        public static IDependencyManager AddJuesJwt(this IDependencyManager dependency)
        {
            dependency.AddJwt<JuesJwtDataProvider, JuesJwtData>();
            dependency.Register<JuesJwtManager>(Lifetimes.Transient);
            return dependency;
        }
    }
}
