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
using Suyaa.DependencyInjection.ServiceCollection;
using Suyaa.Hosting.Kernel.Helpers;

namespace Jues.Kernel
{
    /// <summary>
    /// 启动器
    /// </summary>
    public class KernelStartup : StartupBase
    {
        /// <summary>
        /// 启动器
        /// </summary>
        /// <param name="configuration"></param>
        public KernelStartup(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// 依赖配置
        /// </summary>
        /// <param name="dependency"></param>
        protected override void OnConfigureDependency(IDependencyManager dependency)
        {
            // 处理标准依赖
            base.OnConfigureDependency(dependency);
            // 添加Base模块
            dependency.AddModuler<Jues.Base.Apps.ModuleStartup>();
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        protected override void OnInitialize()
        {
            base.OnInitialize();
            // 引入Base模块
            this.Import<Base.Apps.ModuleStartup>();
        }
    }
}
