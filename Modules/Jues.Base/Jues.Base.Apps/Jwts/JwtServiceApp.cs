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
using Jues.Infrastructure.Jwt;

namespace Jues.Base.Apps.Jwts
{
    /// <summary>
    /// 用户
    /// </summary>
    [JuesJwtAuthorize]
    public sealed class JwtServiceApp : IServiceApp
    {

        #region DI注入

        private readonly IDependencyManager _dependencyManager;
        private readonly JuesJwtManager _juesJwtManager;
        private readonly JwtInfoCore _jwtInfoCore;

        /// <summary>
        /// 用户
        /// </summary>
        public JwtServiceApp(
            IDependencyManager dependencyManager,
            JuesJwtManager juesJwtManager,
            JwtInfoCore jwtInfoCore
            )
        {
            _dependencyManager = dependencyManager;
            _juesJwtManager = juesJwtManager;
            _jwtInfoCore = jwtInfoCore;
        }

        #endregion

        /// <summary>
        /// 获取Jwt内容
        /// </summary>
        /// <returns></returns>
        public async Task<JuesJwtData> GetJwtData()
        {
            var jwtData = _juesJwtManager.GetCurrentData();
            return await Task.FromResult(jwtData);
        }

        /// <summary>
        /// 更新令牌
        /// </summary>
        /// <returns></returns>
        public async Task<JwtTokenOutput> UpdateToken()
        {
            var jwtData = _juesJwtManager.GetCurrentData();
            // 创建令牌
            var jwtTokenOutput = _jwtInfoCore.CreateJwtToken(d =>
            {
                d.Uid = jwtData.Uid;
                d.TenantId = jwtData.TenantId;
                d.Name = jwtData.Name;
            });
            return await Task.FromResult(jwtTokenOutput);
        }
    }
}
