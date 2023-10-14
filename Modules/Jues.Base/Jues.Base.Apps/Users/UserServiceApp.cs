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

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    public sealed class UserServiceApp : IServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly UserInfoCore _userInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserServiceApp(
            IDependencyManager dependencyManager,
            UserInfoCore userInfoCore
            )
        {
            _dependencyManager = dependencyManager;
            _userInfoCore = userInfoCore;
        }

        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public async Task<UserLoginOutput> Login(UserLoginInput input)
        {
            // 获取用户信息
            var userInfo = await _userInfoCore.GetUserInfoRequiredByName(input.UserName);
            // 检测密码是否正确
            if (userInfo.Pwd != input.Password) throw new HostFriendlyException($"密码不正确");
            // 定义返回
            var jwtDataProvider = _dependencyManager.Resolve<IJwtDataProvider>();
            var jwtData = (JwtData)jwtDataProvider.CreateJwtData();
            jwtData.Uid = userInfo.Id;
            return new UserLoginOutput()
            {
                Jwt = sy.Jwt.CreateToken(jwtData)
            };
        }

        /// <summary>
        /// 安装Root用户
        /// </summary>
        /// <returns></returns>
        public async Task SetupRootUser()
        {
            // root用户名
            var userRoot = "root";
            // 检测root用户是否存在
            var userInfo = await _userInfoCore.GetUserInfoByName(userRoot);
            if (userInfo != null) throw new HostFriendlyException($"用户'{userRoot}'已经存在");
            // 添加root用户信息
            await _userInfoCore.InsertOne(new UserInfo()
            {
                Name = userRoot,
                Nick = "超级管理员",
                Pwd = $"user={userRoot};pwd=000000;".GetMD5().ToLower(),
            });
        }
    }
}
