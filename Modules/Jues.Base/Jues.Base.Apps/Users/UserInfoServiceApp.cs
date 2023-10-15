using Jues.Base.Cores.Users;
using Jues.Base.Cores.Users.Dto;
using Jues.Base.Entities.Users;
using Suyaa.Hosting.Kernel.Attributes;
using Suyaa.Hosting.Kernel.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;
using Suyaa;
using Suyaa.DependencyInjection;
using Suyaa.Hosting.Jwt;
using Suyaa.Hosting.Jwt.Dependency;
using Suyaa.Hosting.Jwt.Attributes;
using Jues.Base.Cores.Jwts.Dto;
using Jues.Base.Cores.Jwts;
using Jues.Base.Entities.Migrations;
using Jues.Infrastructure.Helpers;

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    [JwtAuthorize]
    public sealed class UserInfoServiceApp : IServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly IJwtManager _jwtManager;
        private readonly ISession _session;
        private readonly UserInfoCore _userInfoCore;
        private readonly JwtInfoCore _jwtInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserInfoServiceApp(
            IDependencyManager dependencyManager,
            IJwtManager jwtManager,
            ISession session,
            UserInfoCore userInfoCore,
            JwtInfoCore jwtInfoCore
            )
        {
            _dependencyManager = dependencyManager;
            _jwtManager = jwtManager;
            _session = session;
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
            var userInfo = await _userInfoCore.GetUserInfoRequiredById(_session.GetUid());
            // 检测密码是否正确
            if (userInfo.Pwd != input.OldPassword) throw new HostFriendlyException($"旧密码不正确");
            // 存储新密码
            userInfo.Pwd = input.NewPassword;
            await _userInfoCore.UpdateOne(userInfo);
        }
    }
}