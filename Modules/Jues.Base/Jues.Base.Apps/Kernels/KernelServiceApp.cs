using Jues.Base.Cores.Kernels.Dto;
using Suyaa.Hosting.App.Services;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;

namespace Jues.Base.Apps.Kernels
{
    /// <summary>
    /// 内核
    /// </summary>
    public sealed class KernelServiceApp : DomainServiceApp
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
