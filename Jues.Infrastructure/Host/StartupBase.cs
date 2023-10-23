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
using Jues.Infrastructure.Helpers;
using Suyaa.Hosting.AutoMapper.Helpers;
using Suyaa.Hosting.Kernel.Helpers;

namespace Jues.Infrastructure.Host
{
    /// <summary>
    /// 启动器
    /// </summary>
    public abstract class StartupBase : Suyaa.Hosting.HostStartupBase
    {
        // 上传配置
        private readonly StorageOption? _storageOption;
        private readonly JwtOption? _jwtOption;

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
                _jwtOption = jwtSection.Get<JwtOption>();
            }
            #endregion
            #region 初始化上传配置
            var storageSection = configuration.GetSection("Storage");
            if (storageSection != null)
            {
                _storageOption = storageSection.Get<StorageOption>();
            }
            #endregion
        }

        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            // 注册切片
            dependency.AddActionFilters();
            // 添加Jwt支持
            dependency.AddJuesJwt(_jwtOption);
            // 添加对EFCore的支持
            dependency.AddEFCore();
            // 添加上传调用器
            dependency.AddFileStorage(_storageOption);
            // 添加AutoMapper支持
            dependency.AddAutoMapper();
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
