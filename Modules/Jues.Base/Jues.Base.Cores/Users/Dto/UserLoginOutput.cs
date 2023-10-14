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
        /// Jwt信息
        /// </summary>
        public string Jwt { get; set; } = string.Empty;
    }
}
