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
    public sealed class UserServiceApp : IServiceApp
    {
        #region DI注入
        /// <summary>
        /// 用户
        /// </summary>
        public UserServiceApp()
        {

        }
        #endregion

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        public async Task GetTest()
        {
            await Task.CompletedTask;
        }
    }
}
