using Jues.Base.Entities.Files;
using Jues.Base.Entities.Users;
using Jues.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Suyaa.Data;
using Suyaa.Hosting.EFCore.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Base.Entities
{
    /// <summary>
    /// 基础模块数据库上下文
    /// </summary>
    public class BaseDbContext : DefaultContextBase
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

        /// <summary>
        /// 基础模块数据库上下文
        /// </summary>
        /// <param name="dbConnectionDescriptorFactory"></param>
        public BaseDbContext(IDbConnectionDescriptorFactory dbConnectionDescriptorFactory) : base(dbConnectionDescriptorFactory)
        {
        }
    }
}
