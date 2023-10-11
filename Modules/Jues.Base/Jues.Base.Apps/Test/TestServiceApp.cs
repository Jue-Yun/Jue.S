using Suyaa.DependencyInjection;
using Suyaa.Hosting.Kernel.Attributes;
using Suyaa.Hosting.Kernel.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    public sealed class TestServiceApp : IServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;

        /// <summary>
        /// 用户
        /// </summary>
        public TestServiceApp(
            IDependencyManager dependencyManager
            )
        {
            _dependencyManager = dependencyManager;
        }
        #endregion

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        public async Task Test()
        {
            await Task.CompletedTask;
        }
    }
}
