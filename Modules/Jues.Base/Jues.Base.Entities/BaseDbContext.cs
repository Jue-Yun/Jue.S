using Jues.Base.Entities.Files;
using Jues.Base.Entities.Users;
using Jues.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Jues.Base.Entities
{
    /// <summary>
    /// 基础模块数据库上下文
    /// </summary>
    public class BaseDbContext : BasicDbContext
    {
        #region 用户模块
        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<UserInfo> UserInfos { get; set; }
        #endregion

        #region 文件模块
        /// <summary>
        /// 用户信息
        /// </summary>
        public DbSet<FileStorage> FileStorages { get; set; }
        #endregion
    }
}
