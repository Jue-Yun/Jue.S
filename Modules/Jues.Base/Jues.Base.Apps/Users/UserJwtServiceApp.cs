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

namespace Jues.Base.Apps.Users
{
    /// <summary>
    /// 用户
    /// </summary>
    [JwtAuthorize]
    public sealed class UserJwtServiceApp : IServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly IJwtManager _jwtManager;

        /// <summary>
        /// 用户
        /// </summary>
        public UserJwtServiceApp(
            IDependencyManager dependencyManager,
            IJwtManager jwtManager
            )
        {
            _dependencyManager = dependencyManager;
            _jwtManager = jwtManager;
        }

        #endregion

        /// <summary>
        /// 获取Jwt内容
        /// </summary>
        /// <returns></returns>
        public async Task<JwtData> GetJwtData()
        {
            var jwtData = (JwtData)_jwtManager.GetCurrentData();
            return await Task.FromResult(jwtData);
        }
    }
}
