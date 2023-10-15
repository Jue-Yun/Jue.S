using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Jwts.Dto
{
    /// <summary>
    /// Jwt令牌输出
    /// </summary>
    public sealed class JwtTokenOutput
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime Expires { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime Update { get; set; } = DateTime.UtcNow;
    }
}
