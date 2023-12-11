using Jues.Infrastructure;
using Suyaa.Hosting.Infrastructure.Assemblies.Helpers;
using System.Reflection;

namespace Jues.Kernel
{
    /// <summary>
    /// Jues核心应用供应商
    /// </summary>
    public class KernelStartup : BaseStartup
    {
        /// <summary>
        /// 配置程序集
        /// </summary>
        /// <param name="assemblies"></param>
        protected override void OnConfigureAssembly(IList<Assembly> assemblies)
        {
            base.OnConfigureAssembly(assemblies);
            // 引入Base模块
            assemblies.Import<Base.Apps.ModuleStartup>();
        }
    }
}
