using Microsoft.Extensions.DependencyInjection;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Kernel.Attributes;
using Suyaa.Hosting.Kernel.Dependency;
using Suyaa.Hosting.Kernel.Helpers;

[assembly:Module("base")]
namespace Jues.Base.Apps
{
    /// <summary>
    /// 模块启动器
    /// </summary>
    public class ModuleStartup : IModuleStartup
    {
        /// <summary>
        /// 依赖配置
        /// </summary>
        public void ConfigureDependency(IDependencyManager dependency)
        {
            // 添加业务模块
            dependency.AddModuler<Cores.ModuleStartup>();
        }
    }
}
