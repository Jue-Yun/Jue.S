using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.DependencyInjection.ServiceCollection;
using Suyaa.DependencyInjection;

namespace Jues.Infrastructure
{
    /// <summary>
    /// 启动器
    /// </summary>
    public abstract class StartupBase : Suyaa.Hosting.HostStartupBase
    {
        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="configuration"></param>
        public StartupBase(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
        }
        /// <summary>
        /// 应用配置
        /// </summary>
        protected override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialize()
        {
        }
        // 创建依赖管理器
        protected override IDependencyManager OnDependencyManagerCreating(IServiceCollection services)
        {
            return new DependencyManager(services);
        }
    }
}
