using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Users.Dto
{
    /// <summary>
    /// 用户登录入参
    /// </summary>
    public sealed class UserLoginInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
