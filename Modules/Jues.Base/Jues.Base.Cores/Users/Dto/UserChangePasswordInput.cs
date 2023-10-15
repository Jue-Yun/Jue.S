using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Cores.Users.Dto
{
    /// <summary>
    /// 更新密码入参
    /// </summary>
    public sealed class UserChangePasswordInput
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required]
        public string OldPassword { get; set; } = string.Empty;
        /// <summary>
        /// 新密码
        /// </summary>
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
