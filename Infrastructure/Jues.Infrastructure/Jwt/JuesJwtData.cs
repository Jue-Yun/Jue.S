using Suyaa.Hosting.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.Jwt
{
    /// <summary>
    /// jue.S专用Jwt数据
    /// </summary>
    public sealed class JuesJwtData : JwtData
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
