using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.DependencyInjection.ServiceCollection;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Multilingual.Helpers;
using Jues.Configure;
using Suyaa.Hosting.Jwt.Helpers;
using Jues.Infrastructure.Jwt;

namespace Jues.Infrastructure.Host
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
            #region 初始化UUID配置
            var uuidSection = configuration.GetSection("UUID");
            if (uuidSection is null)
            {
                sy.Generator.MachineId = 1;
                sy.Generator.AppId = 1;
            }
            else
            {
                var uuidOption = uuidSection.Get<UuidOption>();
                sy.Generator.MachineId = uuidOption.MachineId;
                sy.Generator.AppId = uuidOption.AppId;
            }
            #endregion

            #region 初始化Jwt配置
            var jwtSection = configuration.GetSection("Jwt");
            if (jwtSection != null)
            {
                var jwtOption = jwtSection.Get<JwtOption>();
                sy.Jwt.TokenName = jwtOption.Header;
                sy.Jwt.TokenKey = jwtOption.Key;
            }
            #endregion
        }
        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            // 添加Jwt支持
            dependency.AddJwt<JuesJwtDataProvider>();
            // 添加对EFCore的支持
            dependency.AddEFCore();
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
