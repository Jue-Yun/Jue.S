using Jues.Base.Cores.Kernels.Dto;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Kernel.Attributes;
using Suyaa.Hosting.Kernel.Dependency;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Apps.Kernels
{
    /// <summary>
    /// 内核
    /// </summary>
    public sealed class KernelServiceApp : ServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;

        /// <summary>
        /// 用户
        /// </summary>
        public KernelServiceApp(
            IDependencyManager dependencyManager
            )
        {
            _dependencyManager = dependencyManager;
        }
        #endregion

        /// <summary>
        /// 获取内核信息
        /// </summary>
        /// <returns></returns>
        public async Task<KernelInfoOutput> GetInfo()
        {
            KernelInfoOutput output = new KernelInfoOutput()
            {
                Name = sy.Assembly.Name,
                Version = sy.Assembly.Version,
            };
            return await Task.FromResult(output);
        }
    }
}
