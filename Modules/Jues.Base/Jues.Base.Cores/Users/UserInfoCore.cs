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
            if (userInfo is null) throw new HostFriendlyException($"用户名'{userName}'不存在");
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

    }
}
