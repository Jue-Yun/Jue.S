﻿using Jues.Infrastructure.EFCore;
using Suyaa.Data.Dependency;

namespace Jues.Base.Entities
{
    /// <summary>
    /// 数据库工厂
    /// </summary>
    public class BaseDbContextFactory : DesignTimeDbContextFactory<BaseDbContext>
    {
        /// <summary>
        /// 创建数据库上下文
        /// </summary>
        /// <param name="dbConnectionDescriptorFactory"></param>
        /// <returns></returns>
        public override BaseDbContext CreateDbContext(IDbConnectionDescriptorFactory dbConnectionDescriptorFactory)
        {
            return new BaseDbContext();
        }
    }
}
