using Jues.Base.Cores.Users.Dto;
using Jues.Base.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Suyaa.Hosting.Data.Dependency;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suyaa.Hosting;
using Suyaa.Hosting.Kernel;
using Suyaa;

namespace Jues.Base.Cores.Users
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public sealed class UserInfoCore : ServiceCore
    {

        #region DI注入

        private readonly IRepository<UserInfo, string> _userInfoRepository;

        /// <summary>
        /// 系统用户
        /// </summary>
        public UserInfoCore(
            IRepository<UserInfo, string> userInfoRepository
            )
        {
            _userInfoRepository = userInfoRepository;
        }

        #endregion

        /// <summary>
        /// 获取查询
        /// </summary>
        /// <returns></returns>
        public IQueryable<UserInfo> GetQuery()
        {
            return _userInfoRepository.Query().AsNoTracking();
        }

        /// <summary>
        /// 获取一个用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfo?> GetUserInfoByName(string userName)
        {
            var userInfo = await GetQuery()
                .Where(d => d.Name == userName)
                .FirstOrDefaultAsync();
            return userInfo;
        }

        /// <summary>
        /// 获取一个用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoRequiredByName(string userName)
        {
            var userInfo = await GetUserInfoByName(userName);
            if (userInfo is null) throw new UserFriendlyException($"用户名'{userName}'不存在");
            return userInfo;
        }

        /// <summary>
        /// 获取一个用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfo?> GetUserInfoById(string id)
        {
            var userInfo = await GetQuery()
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
            return userInfo;
        }

        /// <summary>
        /// 获取一个用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoRequiredById(string id)
        {
            var userInfo = await GetUserInfoById(id);
            if (userInfo is null) throw new UserFriendlyException($"用户Id'{id}'不存在");
            return userInfo;
        }

        /// <summary>
        /// 添加一条用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task InsertOne(UserInfo userInfo)
        {
            await _userInfoRepository.InsertAsync(userInfo);
        }

        /// <summary>
        /// 更新一条用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task UpdateOne(UserInfo userInfo)
        {
            await _userInfoRepository.UpdateAsync(userInfo);
        }

        /// <summary>
        /// 获取密码加密字符串
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> GetPasswordString(string userName, string password)
        {
            return await Task.FromResult($"user={userName};pwd={password};".GetMD5().ToLower());
        }
    }
}
