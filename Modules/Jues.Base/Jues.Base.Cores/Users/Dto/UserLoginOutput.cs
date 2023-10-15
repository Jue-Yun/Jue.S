using Jues.Base.Cores.Jwts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Users.Dto
{
    /// <summary>
    /// 用户登录回参
    /// </summary>
    public sealed class UserLoginOutput
    {
        /// <summary>
        /// Jwt令牌
        /// </summary>
        public JwtTokenOutput JwtToken { get; }

        /// <summary>
        /// 用户登录回参
        /// </summary>
        /// <param name="jwtToken"></param>
        public UserLoginOutput(JwtTokenOutput jwtToken)
        {
            this.JwtToken = jwtToken;
        }
    }
}
