using Suyaa.Data;
using Suyaa.Hosting.EFCore.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jues.Infrastructure.EFCore
{
    /// <summary>
    /// 默认数据库连接上下文
    /// </summary>
    public class DefaultContextBase : Suyaa.EFCore.SqlServer.SqlServerContext
    {
        /// <summary>
        /// 默认数据库连接上下文
        /// </summary>
        /// <param name="descriptorFactory"></param>
        public DefaultContextBase(IDbConnectionDescriptorFactory descriptorFactory) : base(descriptorFactory.DefaultConnection)
        {
        }
    }
}
