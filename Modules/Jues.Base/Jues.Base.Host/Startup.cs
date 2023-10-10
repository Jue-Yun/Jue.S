using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Suyaa.Hosting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jues.Infrastructure;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Kernel.Helpers;
namespace Jues.Base.Host
{
    /// <summary>
    /// 启动器
    /// </summary>
    public class Startup : StartupBase
    {
        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            base.OnConfigureDependency(dependency);
            // 添加模块注册
            dependency.AddModuler<Apps.ModuleStartup>();
        }
    }
}
