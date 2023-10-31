using Jues.Configure;
using Jues.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suyaa;
using Suyaa.DependencyInjection;
using Suyaa.DependencyInjection.ServiceCollection;
using Suyaa.Hosting.AutoMapper.Helpers;
using Suyaa.Hosting.EFCore.Helpers;
using Suyaa.Hosting.Kernel.Helpers;
using Suyaa.Hosting.WebApplicationProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Host
{
    /// <summary>
    /// 基础Jues应用供应商
    /// </summary>
    public abstract class WebApplicationProviderBase : WebAppliactionProvider
    {
        // 上传配置
        private StorageOption? _storageOption;
        private JwtOption? _jwtOption;

        // 获取基目录
        private static string GetBasePath()
        {
            using var processModule = Process.GetCurrentProcess().MainModule;
            var filePath = typeof(Builder).Assembly.Location;
            var folder = sy.IO.GetFolderPath(filePath);
            return folder;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder"></param>
        public override void OnInitialize(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            #region 初始化配置
            string key = "ASPNETCORE_ENVIRONMENT";
            string env = Environment.GetEnvironmentVariable(key) ?? "Prod";
            if (env == "Development") env = "Dev";
            if (Environment.GetEnvironmentVariable(key).IsNullOrWhiteSpace()) Environment.SetEnvironmentVariable(key, env);
            configuration
                .SetBasePath(GetBasePath())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_");
            #endregion

            // 执行基础初始化
            base.OnInitialize(builder);

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
        /// 创建依赖管理器
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        protected override IDependencyManager OnDependencyManagerCreating(IServiceCollection services)
        {
            return new DependencyManager(services);
        }

        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            base.OnConfigureDependency(dependency);
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
    }
}
