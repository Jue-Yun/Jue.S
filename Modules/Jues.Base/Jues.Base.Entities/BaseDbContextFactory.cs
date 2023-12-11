using Jues.Infrastructure.EFCore;
using Suyaa.Data.Dependency;
using Suyaa.Hosting.EFCore.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
