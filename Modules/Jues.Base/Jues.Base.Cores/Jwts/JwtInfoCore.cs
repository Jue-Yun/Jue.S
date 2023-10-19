using Jues.Base.Cores.Jwts.Dto;
using Jues.Base.Entities.Users;
using Jues.Infrastructure.Jwt;
using Suyaa.Hosting.Jwt;
using Suyaa.Hosting.Jwt.Dependency;
using Suyaa.Hosting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Jwts
{
    /// <summary>
    /// Jwt信息
    /// </summary>
    public class JwtInfoCore : ServiceCore
    {
        #region DI注入

        private readonly JuesJwtManager _juesJwtManager;

        /// <summary>
        /// Jwt信息
        /// </summary>
        public JwtInfoCore(
            JuesJwtManager juesJwtManager
            )
        {
            _juesJwtManager = juesJwtManager;
        }

        #endregion

        /// <summary>
        /// 创建Jwt令牌
        /// </summary>
        /// <param name="jwtDataAction"></param>
        /// <returns></returns>
        public JwtTokenOutput CreateJwtToken(Action<JuesJwtData> jwtDataAction)
        {
            var jwtData = _juesJwtManager.Provider.CreateJwtData();
            jwtDataAction(jwtData);
            //jwtData.Uid = userInfo.Id;
            var jwtToken = _juesJwtManager.Provider.Builder.CreateToken(jwtData);
            return new JwtTokenOutput()
            {
                Token = jwtToken.Token,
                Expires = jwtToken.Expires,
                Update = DateTime.UtcNow.AddHours(1)
            };
        }
    }
}
