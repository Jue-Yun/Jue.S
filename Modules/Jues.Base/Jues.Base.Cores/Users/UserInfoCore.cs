using Jues.Base.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Suyaa;
using Suyaa.Data.Dependency;
using Suyaa.Data.Entities;
using Suyaa.Data.Helpers;
using Suyaa.Data.Repositories.Dependency;
using Suyaa.Hosting.Common.Exceptions;
using Suyaa.Hosting.Core.Services;
using System.Linq.Expressions;

namespace Jues.Base.Cores.Users
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public sealed class UserInfoCore : DomainServiceCore
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
        /// 默认仓库
        /// </summary>
        public IRepository<UserInfo, string> Repository => _userInfoRepository;

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
        public async Task InsertData(UserInfo userInfo)
        {
            await _userInfoRepository.InsertAsync(userInfo);
        }

        /// <summary>
        /// 更新一条用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task UpdateData(UserInfo userInfo)
        {
            await _userInfoRepository.UpdateAsync(userInfo, d => d.Id == d.Id);
        }

        /// <summary>
        /// 更新一条用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public async Task UpdateData(UserInfo userInfo, Expression<Func<UserInfo, object>> selector)
        {
            await _userInfoRepository.UpdateAsync(userInfo, selector, d => d.Id == d.Id);
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
