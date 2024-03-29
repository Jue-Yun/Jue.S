﻿using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.DependencyInjection.Helpers;
using Suyaa.Hosting.Common.Modules.Dependency;
using Suyaa.Hosting.Core.Helpers;

namespace Jues.Base.Entities
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
            // 注册依赖
            //dependency.AddModulerCores<ModuleStartup>();
        }
    }
}
