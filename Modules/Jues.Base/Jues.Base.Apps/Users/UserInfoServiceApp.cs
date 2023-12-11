using Jues.Base.Cores.Users;
using Jues.Base.Cores.Users.Dto;
using Jues.Base.Cores.Jwts;
using Jues.Infrastructure.Helpers;
using Jues.Infrastructure.Jwt;
using Suyaa.Hosting.App.Services;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;
using Suyaa.Hosting.Common.Sessions.Dependency;
using Suyaa.Hosting.Common.Exceptions;

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    [JuesJwtAuthorize]
    public sealed class UserInfoServiceApp : DomainServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly ISessionManager _sessionManager;
        private readonly ISession _session;
        private readonly UserInfoCore _userInfoCore;
        private readonly JwtInfoCore _jwtInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserInfoServiceApp(
            IDependencyManager dependencyManager,
            ISessionManager sessionManager,
            UserInfoCore userInfoCore,
            JwtInfoCore jwtInfoCore
            )
        {
            _dependencyManager = dependencyManager;
            _sessionManager = sessionManager;
            _session = _sessionManager.GetSession();
            _userInfoCore = userInfoCore;
            _jwtInfoCore = jwtInfoCore;
        }

        #endregion

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public async Task ChangePassword(UserChangePasswordInput input)
        {
            // 获取用户信息
            var userInfo = await _userInfoCore.GetUserInfoRequiredById(_session.GetUid() ?? string.Empty);
            // 检测密码是否正确
            if (userInfo.Pwd != input.OldPassword) throw new UserFriendlyException($"旧密码不正确");
            // 存储新密码
            userInfo.Pwd = input.NewPassword;
            await _userInfoCore.UpdateOne(userInfo);
        }
    }
}