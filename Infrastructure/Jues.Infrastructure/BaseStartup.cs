using Jues.Infrastructure.Configures;
using Jues.Infrastructure.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suyaa;
using Suyaa.Hosting.AutoMapper.Helpers;
using Suyaa.Hosting.Common.ActionFilters.Helpers;
using Suyaa.Hosting.Common.Configures.Helpers;
using Suyaa.Hosting.Common.DependencyInjection;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Jwt.Helpers;
using Suyaa.Hosting.UnitOfWork.EFCore.Helpers;
using Suyaa.Hosting.WebApplications;
using System.Diagnostics;

namespace Jues.Infrastructure
{
    /// <summary>
    /// 基础Jues应用供应商
    /// </summary>
    public abstract class BaseStartup : HostStartup
    {
        // 上传配置
        private StorageConfig? _storageOption;
        //private JwtConfig? _jwtOption;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnConfigureBuilder(WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.AddConfigures();

            // 执行基础初始化
            base.OnConfigureBuilder(builder);

            // 配置数据库
            builder.AddDatabaseConfigure();

            #region 初始化UUID配置
            builder.AddConfigure<UuidConfig>();
            var uuidSection = configuration.GetSection("UUID");
            var uuidConfig = uuidSection.Get<UuidConfig>();
            if (uuidConfig is null) throw new NotExistException<UuidConfig>();
            sy.Generator.MachineId = uuidConfig.MachineId;
            sy.Generator.AppId = uuidConfig.AppId;
            #endregion

            #region 初始化Jwt配置
            builder.AddJwtConfigure();
            //builder.AddConfigure<JwtConfig>();
            //var jwtSection = configuration.GetSection("Jwt");
            //_jwtOption = jwtSection.Get<JwtConfig>();
            //if (_jwtOption is null) throw new NotExistException<JwtConfig>();
            #endregion

            #region 初始化上传配置
            builder.AddConfigure<StorageConfig>();
            var storageSection = configuration.GetSection("Storage");
            _storageOption = storageSection.Get<StorageConfig>();
            if (_storageOption is null) throw new NotExistException<StorageConfig>();
            #endregion

        }

        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            base.OnConfigureDependency(dependency);
            // 添加Jwt支持
            dependency.AddJuesJwt();
            // 添加对EFCore与工作单元的支持
            dependency.AddEfCoreUnitOfWork();
            // 注册切片
            dependency.AddActionFilters();
            // 添加上传调用器
            dependency.AddFileStorage(_storageOption);
            // 添加AutoMapper支持
            dependency.AddAutoMapper();
        }
    }
}
