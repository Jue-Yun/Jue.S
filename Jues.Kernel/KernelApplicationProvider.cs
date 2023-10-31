using Jues.Infrastructure.Host;
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
    /// Jues核心应用供应商
    /// </summary>
    public class KernelApplicationProvider : WebApplicationProviderBase
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
