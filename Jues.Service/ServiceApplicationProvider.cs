using Jues.Infrastructure.Host;
using Jues.Service;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Kernel.Helpers;
using Suyaa.Hosting.WebApplicationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Kernel
{
    /// <summary>
    /// Jues服务应用供应商
    /// </summary>
    public sealed class ServiceApplicationProvider : KernelApplicationProvider
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder"></param>
        public override void OnInitialize(WebApplicationBuilder builder)
        {
            base.OnInitialize(builder);
            // 使用Windows服务
            builder.Host.UseWindowsService();
        }
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public override void OnConfigureServices(IServiceCollection services)
        {
            base.OnConfigureServices(services);
            // 添加后台服务
            services.AddHostedService<HostBackgroundService>();
        }
    }
}
