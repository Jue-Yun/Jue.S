using Suyaa.Hosting.Common.Attributes;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.Common.Modules.Dependency;
using Suyaa.Hosting.Common.Modules.Helpers;

[assembly: Module("base")]
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
            // 引入程序集
            dependency.Include<ModuleStartup>();
            // 添加业务模块
            dependency.AddModuler<Cores.ModuleStartup>();
        }
    }
}
