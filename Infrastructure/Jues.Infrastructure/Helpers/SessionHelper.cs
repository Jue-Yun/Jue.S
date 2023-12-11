using Suyaa.Hosting.Common.Exceptions;
using Suyaa.Hosting.Common.Sessions.Dependency;

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
        /// <exception cref="UserFriendlyException"></exception>
        public static string? GetUid(this ISession session)
        {
            return (string?)session.Get("Uid");
        }
    }
}
