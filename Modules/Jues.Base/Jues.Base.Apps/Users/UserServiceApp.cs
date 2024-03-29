﻿using Jues.Base.Cores.Users;
using Jues.Base.Cores.Users.Dto;
using Jues.Base.Entities.Users;
using Jues.Base.Cores.Jwts;
using Jues.Base.Cores.Jwts.Dto;
using Microsoft.AspNetCore.Mvc;
using Suyaa.Hosting.App.Services;
using Suyaa.Hosting.Common.Exceptions;
using Suyaa.Hosting.Common.DependencyInjection.Dependency;

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    public sealed class UserServiceApp : DomainServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly UserInfoCore _userInfoCore;
        private readonly JwtInfoCore _jwtInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public UserServiceApp(
            IDependencyManager dependencyManager,
            UserInfoCore userInfoCore,
            JwtInfoCore jwtInfoCore
            )
        {
            _dependencyManager = dependencyManager;
            _userInfoCore = userInfoCore;
            _jwtInfoCore = jwtInfoCore;
        }

        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public async Task<JwtTokenOutput> Login(UserLoginInput input)
        {
            // 获取用户信息
            var userInfo = await _userInfoCore.GetUserInfoRequiredByName(input.UserName);
            // 检测密码是否正确
            if (userInfo.Pwd != input.Password) throw new UserFriendlyException($"密码不正确");
            // 创建令牌
            var jwtTokenOutput = _jwtInfoCore.CreateJwtToken(d =>
            {
                d.Uid = userInfo.Id;
                d.Name = userInfo.Name;
            });
            return jwtTokenOutput;
        }

        /// <summary>
        /// 安装Root用户
        /// </summary>
        /// <returns></returns>
        public async Task SetupRootUser()
        {
            // 定义值
            var userRoot = "root";
            var defaultPassword = "000000";
            var nickRoot = "超级管理员";
            // 检测root用户是否存在
            var userInfo = await _userInfoCore.GetUserInfoByName(userRoot);
            if (userInfo != null) throw new UserFriendlyException($"用户'{userRoot}'已经存在");
            // 添加root用户信息
            await _userInfoCore.InsertData(new UserInfo()
            {
                Name = userRoot,
                Nick = nickRoot,
                Pwd = await _userInfoCore.GetPasswordString(userRoot, defaultPassword),
            });
        }
    }
}
