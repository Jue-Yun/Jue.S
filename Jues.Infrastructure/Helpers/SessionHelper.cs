using Suyaa.Hosting.Kernel.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;

namespace Jues.Infrastructure.Helpers
{
    /// <summary>
    /// 交互信息助手
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        /// <exception cref="HostFriendlyException"></exception>
        public static string GetUid(this ISession session)
        {
            if (session.Uid is null) throw new HostFriendlyException($"用户登录信息获取失败");
            return session.Uid;
        }
    }
}
