using Jues.Service;

namespace Jues.Kernel
{
    /// <summary>
    /// Jues服务应用供应商
    /// </summary>
    public sealed class ServiceStartup : KernelStartup
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnConfigureBuilder(WebApplicationBuilder builder)
        {
            base.OnConfigureBuilder(builder);
            // 使用Windows服务
            builder.Host.UseWindowsService();
        }
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        protected override void OnConfigureServices(IServiceCollection services)
        {
            base.OnConfigureServices(services);
            // 添加后台服务
            services.AddHostedService<HostBackgroundService>();
        }
    }
}
